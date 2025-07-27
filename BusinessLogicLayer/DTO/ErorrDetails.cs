


namespace BusinessLogicLayer.SI.DTO
{
    public class ErorrDetails
    {
         public int StutusCode { get; set; }
         public string ErrorMessage { get; set; }
         public IEnumerable<string>?Errors { get; set; }
        public override string ToString()
      => JsonSerializer.Serialize(this);
    }
}

