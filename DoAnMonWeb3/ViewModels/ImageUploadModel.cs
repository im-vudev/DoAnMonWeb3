namespace DoAnMonWeb3.ViewModels
{
    public class ImageUploadModel
    {
        public IFormFile? AnhDaiDien { get; set; }
        public IFormFile? MatTruocCCCD { get; set; }
        public IFormFile? MatSauCMND { get; set; }
        public List<IFormFile>? OtherImages { get; set; }
    }
}
