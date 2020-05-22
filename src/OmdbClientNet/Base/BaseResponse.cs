namespace OmdbClientNet.Base
{
    public abstract class BaseResponse
    {
        public bool Response { get; set; }

        public int TotalResults { get; set; }
    }
}
