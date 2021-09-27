namespace PokedexApi.Api.InputModels {
    public abstract class PagingParameters {
        const int maxPageSize = 20;
        private int _pageSize = 20;
        private int _pageNumber = 0;
        public int PageNumber {
            get {
                return _pageNumber;
            }
            set {
                _pageNumber = value > 0 ? value : 0;
            }
        }
        public int PageSize {
            get {
                return _pageSize;
            }
            set {
                _pageSize = value < maxPageSize && value > 0 ? value : maxPageSize;
            }
        }
        
    }
}