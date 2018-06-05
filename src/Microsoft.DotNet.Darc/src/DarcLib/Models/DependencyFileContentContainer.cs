using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Microsoft.DotNet.Darc
{
    public class DependencyFileContentContainer
    {
        public DependencyFileContent VersionDetailsXml { get; set; }

        public DependencyFileContent VersionProps { get; set; }

        public DependencyFileContent GlobalJson { get; set; }

        public Dictionary<string, GitHubCommit> GetFilesToCommitMap(string branch, string message = null)
        {
            Dictionary<string, GitHubCommit> gitHubCommitsMap = new Dictionary<string, GitHubCommit>
            {
                { VersionDetailsXml.FilePath, VersionDetailsXml.ToCommit(branch, message) },
                { VersionProps.FilePath, VersionProps.ToCommit(branch, message) },
                { GlobalJson.FilePath, GlobalJson.ToCommit(branch, message) }
            };

            return gitHubCommitsMap;
        }
    }

    public class DependencyFileContent
    {
        public string FilePath { get; }

        public string Content { get; set; }

        public DependencyFileContent(string filePath, XmlDocument xmlDocument)
            : this(filePath, System.Xml.Linq.XElement.Parse(xmlDocument.OuterXml).ToString())
        {
        }

        public DependencyFileContent(string filePath, JObject jsonObject)
            : this(filePath, jsonObject.ToString())
        {
        }

        public DependencyFileContent(string filePath, string content)
        {
            FilePath = filePath;
            Content = content;
        }

        public void Encode()
        {
            byte[] content = System.Text.Encoding.UTF8.GetBytes(Content);
            Content = Convert.ToBase64String(content);
        }

        public GitHubCommit ToCommit(string branch, string message = null)
        {
            message = message ?? $"Darc update of '{FilePath}'";
            Encode();
            GitHubCommit commit = new GitHubCommit(message, Content, branch);
            return commit;
        }
    }
}
