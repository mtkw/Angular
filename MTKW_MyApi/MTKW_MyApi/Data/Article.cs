using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTKW_MyApi.Data
{
    public class Article
    {
        public int ID { get; set; }
        public required string TITLE { get; set; }
        public required int CATEGORY_ID { get; set; }
        [ForeignKey("CATEGORY_ID")]
        [ValidateNever]
        public Category Category { get; set; }
        public required int AUTHOR_ID { get; set; }
        [ForeignKey("AUTHOR_ID")]
        [ValidateNever] 
        public Author Author { get; set; }
        public required DateTime CREATED_AT { get; set; }
    }
}
