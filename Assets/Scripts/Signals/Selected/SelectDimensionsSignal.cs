using Enums;

namespace Signals.Selected
{
    public struct SelectDimensionsSignal
    {
        private DimensionType _dimensionType;
        
        public DimensionType DimensionType => _dimensionType;
        
        public SelectDimensionsSignal(DimensionType dimensionType)
        {
            _dimensionType = dimensionType;
        }
    }
}