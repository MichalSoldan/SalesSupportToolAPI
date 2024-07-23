namespace SalesSupportTool.Api.ViewModels
{
    public class BaseModel
    {
        /// <summary>
        /// Gets or sets Metadata object (non-viewable info mainly intended for LLM to better understand the data)
        /// </summary>
        public object Metadata { get; set; }
    }
}
