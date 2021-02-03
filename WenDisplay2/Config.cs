namespace WenDisplay2
{
    public static class Config
    {
        public static string HaarCascadePath = "haarcascade\\haarcascade_frontalface_default.xml";
        public static string FacePhotosPath = "Source\\Faces\\";
        public static string FaceListTextFile = "Source\\FaceList.txt";
        public static int TimerResponseValue = 500;
        public static string ImageFileExtension = ".bmp";
        public static int ActiveCameraIndex = 1;//0: Default active camera device
    }
}
