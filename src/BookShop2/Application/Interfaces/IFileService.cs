using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Application.Interfaces;

public interface IFileService
{

    Task<(byte[] content, string fileName)?> GetFileByNameAsync(string fileName);  // Admin use
    Task<(byte[] content, string fileName)?> GetUserBookFileAsync(string userId, int bookId); // User use
    bool DeleteFile(string filename);
    IEnumerable<FileInfo> GetAllFiles();
}
