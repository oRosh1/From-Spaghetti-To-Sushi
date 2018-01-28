using System;

namespace ImageProcessingContracts
{
    public interface IProcessImage
    {
        void ProcessImage(string dest, string path);
    }
}
