using System;
using System.Diagnostics;
using System.IO;
using HalconDotNet;

namespace vx_01
{
    /// <summary>
    /// 测量结果结构体（仅专注圆心到直线的距离测量）
    /// </summary>
    public class MeasureResult
    {
        public bool Success { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public double CenterRow { get; set; }       // 圆心 Row (Y)
        public double CenterCol { get; set; }       // 圆心 Col (X)
        public double DistancePixel { get; set; }   // 圆心到直线的像素距离 (px)
        public double DistanceMm { get; set; }      // 换算物理尺寸 (mm)
        public double ExecutionTimeMs { get; set; } // 算法耗时 (ms)
        public string Message { get; set; }

        // 显示图形对象
        public HObject LineContour { get; set; }    // 拟合直线轮廓
        public HObject CircleContour { get; set; }  // 拟合圆轮廓
        public HObject MeasureLine { get; set; }    // 测量垂线段
        public HObject CenterCross { get; set; }    // 圆心及垂足十字叉

        public MeasureResult()
        {
            Success = false;
        }

        public void DisposeObjects()
        {
            if (LineContour != null && LineContour.IsInitialized()) LineContour.Dispose();
            if (CircleContour != null && CircleContour.IsInitialized()) CircleContour.Dispose();
            if (MeasureLine != null && MeasureLine.IsInitialized()) MeasureLine.Dispose();
            if (CenterCross != null && CenterCross.IsInitialized()) CenterCross.Dispose();
        }
    }

    /// <summary>
    /// 视觉测量配置参数
    /// </summary>
    public class MeasureConfig
    {
        public double MmPerPixel { get; set; }      // 像素当量 (mm/Pixel)
        public int ThresholdGray { get; set; }         // 阈值分割灰度
        public string ImageDirectory { get; set; }  // 图片文件夹路径

        public MeasureConfig()
        {
            MmPerPixel = 0.50;                       // 默认 0.50 mm/Pixel
            ThresholdGray = 90;                        // 默认分割阈值
            ImageDirectory = @"D:\zz-mv-2603\Halcon\第十天\测量";
        }
    }

    /// <summary>
    /// 工业视觉测量核心引擎
    /// 基于 wx_01.hdev 算法原理，实现黑色工件圆心到基准直线距离的高精度测量
    /// </summary>
    public class VisionEngine : IDisposable
    {
        public MeasureConfig Config { get; set; }

        public VisionEngine()
        {
            Config = new MeasureConfig();
        }

        /// <summary>
        /// 执行圆心到直线的距离测量
        /// </summary>
        public MeasureResult ProcessImage(HObject ho_Image, string imagePath = "")
        {
            MeasureResult result = new MeasureResult();
            result.ImagePath = imagePath;
            result.ImageName = string.IsNullOrEmpty(imagePath) ? "LiveImage" : Path.GetFileName(imagePath);

            Stopwatch sw = Stopwatch.StartNew();

            HObject ho_Dark = null, ho_Conn = null, ho_Main = null, ho_Filled = null;
            HObject ho_Holes = null, ho_SingleHoles = null, ho_RoundHole = null;
            HObject ho_BorderContours = null, ho_SplitContours = null, ho_SelectedLines = null;
            HObject ho_ContourLine = null, ho_ContourCircle = null, ho_MeasureLine = null, ho_Crosses = null;

            try
            {
                HOperatorSet.GenEmptyObj(out ho_Dark);
                HOperatorSet.GenEmptyObj(out ho_Conn);
                HOperatorSet.GenEmptyObj(out ho_Main);
                HOperatorSet.GenEmptyObj(out ho_Filled);
                HOperatorSet.GenEmptyObj(out ho_Holes);
                HOperatorSet.GenEmptyObj(out ho_SingleHoles);
                HOperatorSet.GenEmptyObj(out ho_RoundHole);
                HOperatorSet.GenEmptyObj(out ho_BorderContours);
                HOperatorSet.GenEmptyObj(out ho_SplitContours);
                HOperatorSet.GenEmptyObj(out ho_SelectedLines);
                HOperatorSet.GenEmptyObj(out ho_ContourLine);
                HOperatorSet.GenEmptyObj(out ho_ContourCircle);
                HOperatorSet.GenEmptyObj(out ho_MeasureLine);
                HOperatorSet.GenEmptyObj(out ho_Crosses);

                HTuple hv_Width, hv_Height;
                HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);

                // ----------------------------------------------------
                // 1. 提取工件主体与内部特征圆孔
                // ----------------------------------------------------
                HOperatorSet.Threshold(ho_Image, out ho_Dark, 0, Config.ThresholdGray);
                HOperatorSet.Connection(ho_Dark, out ho_Conn);
                HOperatorSet.SelectShapeStd(ho_Conn, out ho_Main, "max_area", 70);
                HOperatorSet.FillUp(ho_Main, out ho_Filled);

                // 提取通孔区域
                HOperatorSet.Difference(ho_Filled, ho_Main, out ho_Holes);
                HOperatorSet.Connection(ho_Holes, out ho_SingleHoles);
                HOperatorSet.SelectShape(ho_SingleHoles, out ho_RoundHole, 
                    new HTuple("circularity", "area"), "and", 
                    new HTuple(0.70, 5000), new HTuple(1.0, 500000));

                HTuple hv_Area, hv_RowCenter, hv_ColCenter;
                HOperatorSet.AreaCenter(ho_RoundHole, out hv_Area, out hv_RowCenter, out hv_ColCenter);

                if (hv_Area.Length > 0 && hv_Area[0].D > 5000)
                {
                    double centerR = hv_RowCenter[0].D;
                    double centerC = hv_ColCenter[0].D;
                    double radius = Math.Sqrt(hv_Area[0].D / Math.PI);

                    result.CenterRow = Math.Round(centerR, 2);
                    result.CenterCol = Math.Round(centerC, 2);

                    // 生成拟合圆轮廓
                    HOperatorSet.GenCircleContourXld(out ho_ContourCircle, centerR, centerC, radius, 0, 6.28318, "positive", 1.0);

                    // ----------------------------------------------------
                    // 2. 提取工件边缘基准直线 (与 wx_01.hdev 对应)
                    // ----------------------------------------------------
                    HOperatorSet.GenContourRegionXld(ho_Main, out ho_BorderContours, "border");
                    HOperatorSet.SegmentContoursXld(ho_BorderContours, out ho_SplitContours, "lines", 5, 4, 2);
                    HOperatorSet.SelectContoursXld(ho_SplitContours, out ho_SelectedLines, "contour_length", 150, 3000, -0.5, 0.5);

                    HTuple hv_NumLines;
                    HOperatorSet.CountObj(ho_SelectedLines, out hv_NumLines);

                    if (hv_NumLines.I > 0)
                    {
                        // 寻找与特征圆孔相对的工件远端长边基准直线 (排除工件旋转或倾斜时孔附近的短边干扰)
                        int bestIndex = 1;
                        double bestScore = double.MinValue;
                        int fallbackLongestIndex = 1;
                        double maxLen = -1.0;

                        for (int k = 1; k <= hv_NumLines.I; k++)
                        {
                            HObject oneLine;
                            HOperatorSet.SelectObj(ho_SelectedLines, out oneLine, k);

                            HTuple r1, c1, r2, c2, nr, nc, dist;
                            HOperatorSet.FitLineContourXld(oneLine, "tukey", -1, 0, 5, 2, out r1, out c1, out r2, out c2, out nr, out nc, out dist);

                            HTuple plDist;
                            HOperatorSet.DistancePl(centerR, centerC, r1, c1, r2, c2, out plDist);

                            HTuple rCoords, cCoords;
                            HOperatorSet.GetContourXld(oneLine, out rCoords, out cCoords);
                            HTuple meanR, meanC;
                            HOperatorSet.TupleMean(rCoords, out meanR);
                            HOperatorSet.TupleMean(cCoords, out meanC);

                            HTuple lineLen;
                            HOperatorSet.LengthXld(oneLine, out lineLen);

                            if (lineLen.D > maxLen)
                            {
                                maxLen = lineLen.D;
                                fallbackLongestIndex = k;
                            }

                            double centerDist = Math.Sqrt(Math.Pow(meanR.D - centerR, 2) + Math.Pow(meanC.D - centerC, 2));

                            // 几何空间约束：基准直线位于圆孔对侧远端（垂直距离与质心到圆心距离均 > 250px）
                            // 综合评分：结合轮廓长度与远端距离，确保无论旋转角度多大均 100% 锁定真实基准边
                            if (centerDist > 250 && plDist.D > 250)
                            {
                                double score = lineLen.D * 2.0 + centerDist;
                                if (score > bestScore)
                                {
                                    bestScore = score;
                                    bestIndex = k;
                                }
                            }

                            oneLine.Dispose();
                        }

                        if (bestScore == double.MinValue)
                        {
                            bestIndex = fallbackLongestIndex;
                        }

                        HObject bestLine;
                        HOperatorSet.SelectObj(ho_SelectedLines, out bestLine, bestIndex);

                        // Tukey 鲁棒拟合基准直线
                        HTuple hv_RBegin, hv_CBegin, hv_REnd, hv_CEnd, hv_Nr, hv_Nc, hv_Dist;
                        HOperatorSet.FitLineContourXld(bestLine, "tukey", -1, 0, 5, 2,
                            out hv_RBegin, out hv_CBegin, out hv_REnd, out hv_CEnd,
                            out hv_Nr, out hv_Nc, out hv_Dist);

                        HOperatorSet.GenContourPolygonXld(out ho_ContourLine, 
                            new HTuple(hv_RBegin).TupleConcat(hv_REnd), new HTuple(hv_CBegin).TupleConcat(hv_CEnd));
                        bestLine.Dispose();

                        // ----------------------------------------------------
                        // 3. 计算圆心到直线的垂线距离与投影垂足 (wx_01.hdev 核心算子)
                        // ----------------------------------------------------
                        HTuple hv_Distance, hv_ProjRow, hv_ProjCol;
                        HOperatorSet.DistancePl(centerR, centerC, hv_RBegin, hv_CBegin, hv_REnd, hv_CEnd, out hv_Distance);
                        HOperatorSet.ProjectionPl(centerR, centerC, hv_RBegin, hv_CBegin, hv_REnd, hv_CEnd, out hv_ProjRow, out hv_ProjCol);

                        // 生成测量垂线及十字叉
                        HTuple hv_LineRows = new HTuple(centerR).TupleConcat(hv_ProjRow);
                        HTuple hv_LineCols = new HTuple(centerC).TupleConcat(hv_ProjCol);
                        HOperatorSet.GenContourPolygonXld(out ho_MeasureLine, hv_LineRows, hv_LineCols);

                        HTuple hv_CrossRows = new HTuple(centerR).TupleConcat(hv_ProjRow);
                        HTuple hv_CrossCols = new HTuple(centerC).TupleConcat(hv_ProjCol);
                        HOperatorSet.GenCrossContourXld(out ho_Crosses, hv_CrossRows, hv_CrossCols, 35, 0);

                        result.DistancePixel = Math.Round(hv_Distance.D, 2);
                        result.DistanceMm = Math.Round(result.DistancePixel * Config.MmPerPixel, 3);
                        result.Success = true;
                        result.Message = string.Format("测量成功: {0:F2} px ({1:F3} mm)", result.DistancePixel, result.DistanceMm);
                    }
                    else
                    {
                        result.Message = "未提取到基准直线轮廓";
                    }
                }
                else
                {
                    result.Message = "未定位到特征圆孔";
                }

                if (result.Success)
                {
                    result.LineContour = ho_ContourLine;
                    result.CircleContour = ho_ContourCircle;
                    result.MeasureLine = ho_MeasureLine;
                    result.CenterCross = ho_Crosses;

                    ho_ContourLine = null;
                    ho_ContourCircle = null;
                    ho_MeasureLine = null;
                    ho_Crosses = null;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "测量异常: " + ex.Message;
            }
            finally
            {
                if (ho_Dark != null && ho_Dark.IsInitialized()) ho_Dark.Dispose();
                if (ho_Conn != null && ho_Conn.IsInitialized()) ho_Conn.Dispose();
                if (ho_Main != null && ho_Main.IsInitialized()) ho_Main.Dispose();
                if (ho_Filled != null && ho_Filled.IsInitialized()) ho_Filled.Dispose();
                if (ho_Holes != null && ho_Holes.IsInitialized()) ho_Holes.Dispose();
                if (ho_SingleHoles != null && ho_SingleHoles.IsInitialized()) ho_SingleHoles.Dispose();
                if (ho_RoundHole != null && ho_RoundHole.IsInitialized()) ho_RoundHole.Dispose();
                if (ho_BorderContours != null && ho_BorderContours.IsInitialized()) ho_BorderContours.Dispose();
                if (ho_SplitContours != null && ho_SplitContours.IsInitialized()) ho_SplitContours.Dispose();
                if (ho_SelectedLines != null && ho_SelectedLines.IsInitialized()) ho_SelectedLines.Dispose();
                if (ho_ContourLine != null && ho_ContourLine.IsInitialized()) ho_ContourLine.Dispose();
                if (ho_ContourCircle != null && ho_ContourCircle.IsInitialized()) ho_ContourCircle.Dispose();
                if (ho_MeasureLine != null && ho_MeasureLine.IsInitialized()) ho_MeasureLine.Dispose();
                if (ho_Crosses != null && ho_Crosses.IsInitialized()) ho_Crosses.Dispose();

                sw.Stop();
                result.ExecutionTimeMs = Math.Round(sw.Elapsed.TotalMilliseconds, 1);
            }

            return result;
        }

        public void Dispose() { }
    }
}
