using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace projectduplicator_2017
{
  public class DirectoryTreeViewOnDemand : LoadOnDemandTreeView, ISupportInitialize
  {
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new TreeNodeCollection Nodes
    {
      get
      {
        return base.Nodes;
      }
    }

    protected override void OnLoadData(TreeViewCancelEventArgs e)
    {
      base.OnLoadData(e);
      if (e.Action != TreeViewAction.Expand)
        return;
      try
      {
        DirectoryInfo directoryInfo = new DirectoryInfo(e.Node.FullPath);
        if (directoryInfo == null)
          return;
        foreach (FileSystemInfo fileSystemInfo in directoryInfo.GetFileSystemInfos())
        {
          Type type = fileSystemInfo.GetType();
          if (type == typeof (DirectoryInfo))
          {
            TreeNode treeNode = new TreeNode(fileSystemInfo.Name);
            if (this.ImageList != null && this.ImageList.Images.Count > 1)
            {
              treeNode.ImageIndex = 1;
              treeNode.SelectedImageIndex = 1;
            }
            this.FakeNode(treeNode);
            e.Node.Nodes.Add(treeNode);
          }
          else if (type == typeof (FileInfo))
          {
            FileInfo fileInfo = (FileInfo) fileSystemInfo;
            if (Path.GetExtension(fileInfo.FullName) == ".*")
            {
              TreeNode node = new TreeNode(fileInfo.Name);
              if (this.ImageList != null && this.ImageList.Images.Count > 2)
              {
                node.ImageIndex = 2;
                node.SelectedImageIndex = 2;
              }
              e.Node.Nodes.Add(node);
            }
          }
        }
      }
      catch
      {
        e.Cancel = true;
        this.FakeNode(e.Node);
      }
    }

    public void BeginInit()
    {
      this.Nodes.Clear();
    }

    public void EndInit()
    {
      TreeNode treeNode = new TreeNode(Projektduplicator_2017.Properties.Settings.Default.pathNosDup_alt);
      if (this.ImageList != null && this.ImageList.Images.Count > 1)
      {
        treeNode.ImageIndex = 1;
        treeNode.SelectedImageIndex = 1;
      }
      this.FakeNode(treeNode);
      this.Nodes.Add(treeNode);
    }
  }
}
