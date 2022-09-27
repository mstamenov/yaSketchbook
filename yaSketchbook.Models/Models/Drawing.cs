namespace yaSketchbook.Models.Models;

[Table("Drawings")]
public partial class Drawing : IModel
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime ModifyDate { get; set; }
    
    public string Name { get; set; }

    public string Json { get; set; }
}
