using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItemManagementSystem.Domain.DataModels;

public class ItemRequestDetail
{
  [Key]
  public int Id { get; set; }

  [ForeignKey("ItemRequest")]
  public int ItemRequestId { get; set; }
  public ItemRequest ItemRequest { get; set; } = null!;

  [ForeignKey("ItemModel")]
  public int ItemModelId { get; set; }
  public ItemModel ItemModel { get; set; } = null!;

  public int Quantity { get; set; }
  public bool IsDeleted { get; set; } = false;

  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

  public DateTime? UpdatedAt { get; set; }

  [ForeignKey("CreatedByUser")]
  public int CreatedBy { get; set; }
  public User? CreatedByUser { get; set; }

  [ForeignKey("ModifiedByUser")]
  public int? ModifiedBy { get; set; }
  public User? ModifiedByUser { get; set; }

  public ICollection<ItemModel> ItemModels { get; set; } = new List<ItemModel>();
}
