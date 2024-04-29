/*
    Copyright (c) 2017 Marcin Szeniak (https://github.com/Klocman/)
    Apache License Version 2.0
*/

using System;
using System.Diagnostics;
using System.IO;

namespace Klocman.IO
{
    /// <summary>
    ///     Advanced file information
    /// </summary>
    public class AdvancedFileInfo
    {
        private readonly FileInfo _fileInfo;
        private readonly FileVersionInfo _versionInfo;

        private AdvancedFileInfo(FileInfo fileInfo, FileVersionInfo versionInfo)
        {
            _fileInfo = fileInfo;
            _versionInfo = versionInfo;
        }

        public DateTime CreationTime
        {
            get { return _fileInfo.CreationTime; }
            set { _fileInfo.CreationTime = value; }
        }

        public DateTime LastAccessTime
        {
            get { return _fileInfo.LastAccessTime; }
            set { _fileInfo.LastAccessTime = value; }
        }

        public DateTime LastWriteTime
        {
            get { return _fileInfo.LastWriteTime; }
            set { _fileInfo.LastWriteTime = value; }
        }

        public FileAttributes Attributes
        {
            get { return _fileInfo.Attributes; }
            set { _fileInfo.Attributes = value; }
        }

        public bool IsReadOnly
        {
            get { return _fileInfo.IsReadOnly; }
            set { _fileInfo.IsReadOnly = value; }
        }

        public string FullName => _fileInfo.FullName;

        public string FileName => _fileInfo.Name;

        public FileSize Size => FileSize.FromBytes(_fileInfo.Length);

        public DirectoryInfo Directory => _fileInfo.Directory;

        public bool Exists => _fileInfo.Exists;

        public string Comments => _versionInfo?.Comments;

        public string CompanyName => _versionInfo?.CompanyName;

        public string FileDescription => _versionInfo?.FileDescription;

        public Version FileVersion => _versionInfo == null
            ? null
            : new Version(_versionInfo.FileMajorPart, _versionInfo.FileMinorPart, _versionInfo.FileBuildPart,
                _versionInfo.FilePrivatePart);

        public string InternalName => _versionInfo?.InternalName;

        public string Language => _versionInfo?.Language;

        public string LegalCopyright => _versionInfo?.LegalCopyright;

        public string LegalTrademarks => _versionInfo?.LegalTrademarks;

        public string OriginalFilename => _versionInfo?.OriginalFilename;

        public string ProductName => _versionInfo?.ProductName;

        public Version ProductVersion => _versionInfo == null
            ? null
            : new Version(_versionInfo.ProductMajorPart, _versionInfo.ProductMinorPart,
                _versionInfo.ProductBuildPart, _versionInfo.ProductPrivatePart);

        public static AdvancedFileInfo FromPath(string filePath)
        {
            FileVersionInfo fileVersionInfo;

            try
            {
                fileVersionInfo = FileVersionInfo.GetVersionInfo(filePath);
            }
            catch
            {
                fileVersionInfo = null;
            }

            return new AdvancedFileInfo(new FileInfo(filePath), fileVersionInfo);
        }
    }
}