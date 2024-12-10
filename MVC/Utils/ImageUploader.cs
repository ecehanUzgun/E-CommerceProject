
namespace MVC.Utils
{
    public class ImageUploader
    {
        public static string UploadImage(IFormFile image, string uploadPath)
        {
            //gelen image isimli dosyanın uzantısı alınacak. Eğer bu uzantı aşağıdakilerden herhangi birine eşit ise görselin yüklenmesine izin verilecek.
            //.png, .jpg, .jpeg, .gif

          string newImageName=  ValidateImage(image.FileName);
            if (newImageName != null)
            {
                //uploadPath tarafından iletilen yol projede dahil değilse.
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
               string filePath= Path.Combine(uploadPath, newImageName);

             
                //using halihazırda bir kopyalama işlemini gerçekleştirdikten sonra işleme devam etmemesi için tanımlandı.
                using (var stream=new FileStream(filePath, FileMode.Create))
                {
                  image.CopyTo(stream);
                    
                }

                    return newImageName;
            }
            return null;

        }

        public static string ValidateImage(string imageName) //manzara.güzel.sonbahar.jpg
        {
          string[] itemArray=  imageName.Split(".");

            var extension = itemArray[itemArray.Length - 1]; //jpg



            //Validation
            if (extension == "jpg" || extension == "png" || extension == "jpeg")
            {
                var uniqueName = Guid.NewGuid().ToString();

                var newImageName = uniqueName + "." + extension;

                return newImageName;
            }

            return null;

           
        }
    }
}
