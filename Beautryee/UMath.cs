using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Beautryee
{
    /// <summary>
    /// 数学扩展类
    /// </summary>
    public static class MathEx
    {
        public static double CalcDistance(PointF pt1, PointF pt2)
        {
            float xx = pt1.X - pt2.X;
            float yy = pt1.Y - pt2.Y;
            return Math.Sqrt(xx * xx + yy * yy);
        }

        public static double CalcDistance(Point pt1, Point pt2)
        {
            int xx = pt1.X - pt2.X;
            int yy = pt1.Y - pt2.Y;
            return Math.Sqrt(xx * xx + yy * yy);
        }

        public static double CalcAngle(Point thisPoint, Point toPoint)
        {
            double az = Math.Atan2(thisPoint.Y - toPoint.Y, thisPoint.X - toPoint.X) * 180 / Math.PI;
            az = (az - 270 + 720) % 360;
            return az;
        }

        public static double CalcAngle(PointF thisPoint, PointF toPoint)
        {
            double az = Math.Atan2(thisPoint.Y - toPoint.Y, thisPoint.X - toPoint.X) * 180 / Math.PI;
            az = (az - 270 + 720) % 360;
            return az;
        }

        public static T CheckLowerLimit<T>(this T obj, T lowerLimit) where T : IComparable
        {
            return obj.CompareTo(lowerLimit) == -1 ? lowerLimit : obj;
        }

        public static T CheckUpperLimit<T>(this T obj, T upperLimit) where T : IComparable
        {
            return obj.CompareTo(upperLimit) == 1 ? upperLimit : obj;
        }

        public static T CheckRange<T>(this T obj, T lowerLimit, T upperLimit) where T : IComparable
        {
            if (lowerLimit.CompareTo(upperLimit) == -1)
                return obj.CheckLowerLimit(lowerLimit).CheckUpperLimit(upperLimit);
            else if (lowerLimit.CompareTo(upperLimit) == 1)
                return obj.CheckLowerLimit(upperLimit).CheckUpperLimit(lowerLimit);
            else
                return lowerLimit;
        }

        /// <summary>
        /// 点是否在区域内
        /// </summary>
        /// <param name="point">点</param>
        /// <param name="region">区域范围</param>
        /// <returns>是否在区域内</returns>
        public static bool InRegion(this Point point, Region region)
        {
            return region.IsVisible(point);
        }

        /// <summary>
        /// 点是否在区域内
        /// </summary>
        /// <param name="point">点</param>
        /// <param name="points">区域范围</param>
        /// <returns>是否在区域内</returns>
        public static bool InRegion(this Point point, Point[] points)
        {
            using (GraphicsPath path = points.Path())
            {
                using (Region region = path.Region())
                {
                    return region.IsVisible(point);
                }
            }
        }

        /// <summary>
        /// 点是否在区域内
        /// </summary>
        /// <param name="point">点</param>
        /// <param name="points">区域范围</param>
        /// <returns>是否在区域内</returns>
        public static bool InRegion(this PointF point, PointF[] points)
        {
            using (GraphicsPath path = points.Path())
            {
                using (Region region = path.Region())
                {
                    return region.IsVisible(point);
                }
            }
        }

        /// <summary>
        /// 创建路径
        /// </summary>
        /// <param name="points">点集合</param>
        /// <returns>路径</returns>
        public static GraphicsPath Path(this Point[] points)
        {
            GraphicsPath path = new GraphicsPath();
            path.Reset();
            path.AddPolygon(points);
            return path;
        }

        /// <summary>
        /// 创建路径
        /// </summary>
        /// <param name="points">点集合</param>
        /// <returns>路径</returns>
        public static GraphicsPath Path(this PointF[] points)
        {
            GraphicsPath path = new GraphicsPath();
            path.Reset();
            path.AddPolygon(points);
            return path;
        }

        /// <summary>
        /// 创建区域
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>区域</returns>
        public static Region Region(this GraphicsPath path)
        {
            Region region = new Region();
            region.MakeEmpty();
            region.Union(path);
            return region;
        }

        /// <summary>
        /// 除取余
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="divParam">除数</param>
        /// <returns>结果</returns>
        public static int Mod(this int value, int divParam)
        {
            return value % divParam;
        }

        /// <summary>
        /// 角度转弧度
        /// </summary>
        /// <param name="d">角度</param>
        /// <returns>弧度</returns>
        public static double Rad(this double d)
        {
            return d * Math.PI / 180.0;
        }

        /// <summary>
        /// 弧度转角度
        /// </summary>
        /// <param name="rad">弧度</param>
        /// <returns>角度</returns>
        public static double Deg(this double rad)
        {
            return rad * 180.0 / Math.PI;
        }

        /// <summary>
        /// 角度转弧度
        /// </summary>
        /// <param name="d">角度</param>
        /// <returns>弧度</returns>
        public static double Rad(this float d)
        {
            return d * Math.PI / 180.0;
        }

        /// <summary>
        /// 弧度转角度
        /// </summary>
        /// <param name="rad">弧度</param>
        /// <returns>角度</returns>
        public static double Deg(this float rad)
        {
            return rad * 180.0 / Math.PI;
        }
    }
}