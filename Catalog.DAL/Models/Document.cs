using System.Collections.Specialized;

namespace Catalog.DAL.Model
{
    public class Document
    {
        public OrderedDictionary Fields { get; set; }
        public int[] AnnotationFields { get; set; }

        public Document(params int[] annotationFields)
        {
            Fields = new OrderedDictionary();
            AnnotationFields = annotationFields;
        }

        public Document(OrderedDictionary dictionary)
        {
            Fields = dictionary;
        }
    }
}
