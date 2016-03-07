using System.Threading;

namespace TestOxyPlot
{
    using System;

    using OxyPlot;
    using OxyPlot.Series;
    using OxyPlot.Axes;

    public class MainViewModel
    {
        public MainViewModel()
        {
            SetupTopModel();
            SetupBottomModel();
        }

        private void SetupTopModel()
        {
            TopModel = new PlotModel
            {
                Title = "RX0001a",
                LegendTitle = "Legend",
                LegendOrientation = LegendOrientation.Horizontal,
                LegendPlacement = LegendPlacement.Inside,
                LegendPosition = LegendPosition.TopRight,
                LegendBackground = OxyColor.FromAColor(200, OxyColors.White),
                LegendBorder = OxyColors.Black
            };
            TopModel.Axes.Add(new LinearAxis
            {
                Title="Amplitude",
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Position = AxisPosition.Left,
                Minimum = 0,
                Maximum = 1
            });
            TopModel.Axes.Add(new LinearAxis
            {
                Title="Range",
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Position = AxisPosition.Bottom,
                Minimum = 0,
                Maximum = 1
            });

            //TopModel.Axes.Add(
            //    new LinearColorAxis
            //    {
            //        Position = AxisPosition.Right,
            //        Palette = OxyPalettes.Jet(200)
            //    });

            //TopModel.Series.Add(
            //    new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));
            //TopModel.Series.Add(
            //    new FunctionSeries(Math.Sin, 0, 10, 0.1, "sin(x)"));
            //TopModel.Series.Add(
            //    new FunctionSeries(Math.Tan, 0, 10, 0.1, "tan(x)"));
            var topSeries =
                new ScatterSeries {MarkerType = MarkerType.Circle, Title = "Rx"};
            var r = new Random(314);
            for (var i = 0; i < 1000; i++)
            {
                var x = r.NextDouble();
                var y = r.NextDouble();
                //var size = r.Next(5, 15);
                const int size = 2;
                const int colorValue = 5; //r.Next(100, 1000);
                topSeries.Points.Add(
                    new ScatterPoint(x, y, size, colorValue));
            }
            topSeries.RenderInLegend = true;
            TopModel.Series.Add(topSeries);
        }
        private void SetupBottomModel()
        {
            BottomModel = new PlotModel
            {
                LegendTitle = "Legend",
                LegendOrientation = LegendOrientation.Horizontal,
                LegendPlacement = LegendPlacement.Inside,
                LegendPosition = LegendPosition.TopRight,
                LegendBackground = OxyColor.FromAColor(200, OxyColors.White),
                LegendBorder = OxyColors.Black
            };
            BottomModel.Axes.Add(new LinearAxis
            {
                Title = "Phase",
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Position = AxisPosition.Left,
                Minimum = 0,
                Maximum = 1
            });
            BottomModel.Axes.Add(new LinearAxis
            {
                Title = "Range",
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Position = AxisPosition.Bottom,
                Minimum = 0,
                Maximum = 1
            });

            //BottomModel.Axes.Add(
            //    new LinearColorAxis
            //    {
            //        Position = AxisPosition.Right,
            //        Palette = OxyPalettes.Jet(200)
            //    });

            //TopModel.Series.Add(
            //    new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));
            //TopModel.Series.Add(
            //    new FunctionSeries(Math.Sin, 0, 10, 0.1, "sin(x)"));
            //TopModel.Series.Add(
            //    new FunctionSeries(Math.Tan, 0, 10, 0.1, "tan(x)"));
            var bottomSeries =
                new ScatterSeries { MarkerType = MarkerType.Circle, Title = "Tx" };
            var r = new Random(314);
            for (var i = 0; i < 1000; i++)
            {
                var x = r.NextDouble();
                var y = r.NextDouble();
                //var size = r.Next(5, 15);
                const int size = 2;
                const int colorValue = 5; //r.Next(100, 1000);
                bottomSeries.Points.Add(
                    new ScatterPoint(x, y, size, colorValue));
            }
            bottomSeries.RenderInLegend = true;
            BottomModel.Series.Add(bottomSeries);
        }

        public PlotModel TopModel { get; private set; }
        public PlotModel BottomModel { get; private set; }
    }
}
