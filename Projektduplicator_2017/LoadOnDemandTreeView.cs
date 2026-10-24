using System.Windows.Forms;

namespace projectduplicator_2017
{
  public class LoadOnDemandTreeView : TreeView
  {
    private bool _blnFakeNodes = true;

    public bool FakeNodes
    {
      get
      {
        return this._blnFakeNodes;
      }
      set
      {
        this._blnFakeNodes = value;
      }
    }

    public event TreeViewCancelEventHandler LoadData;

    public bool FakeNode(TreeNode pTreeNodeToFake)
    {
      bool flag = false;
      if (pTreeNodeToFake != null && !pTreeNodeToFake.IsExpanded && pTreeNodeToFake.Nodes.Count == 0)
      {
        pTreeNodeToFake.Nodes.Add(new TreeNode("fake")
        {
          Tag = (object) "fake"
        });
        flag = true;
      }
      return flag;
    }

    protected override void OnBeforeExpand(TreeViewCancelEventArgs e)
    {
      if (this._blnFakeNodes && e.Node.Nodes.Count > 0 && (e.Node.Nodes[0].Tag != null && e.Node.Nodes[0].Tag.ToString() == "fake"))
      {
        e.Node.Nodes.Clear();
        this.OnLoadData(e);
      }
      base.OnBeforeExpand(e);
    }

    protected override void OnAfterCollapse(TreeViewEventArgs e)
    {
      base.OnAfterCollapse(e);
      if (!this._blnFakeNodes)
        return;
      e.Node.Nodes.Clear();
      e.Node.Nodes.Add(new TreeNode("fake")
      {
        Tag = (object) "fake"
      });
    }

    protected virtual void OnLoadData(TreeViewCancelEventArgs e)
    {
      if (this.LoadData == null)
        return;
      this.LoadData((object) this, e);
    }
  }
}
