using FluentValidation;
using InternetStore.Domain;

namespace InternetStore.Models;
public class ProductCart
{
    public string Id { get; set; }

    public string Image { get; set; }

    public string Title { get; set; }

    public int Price { get; set; }

    public string Size { get; set; }

    public int Quantity { get; set; }
}

public class ProductCartValidation : AbstractValidator<ProductCart>
{
    public ProductCartValidation()
    {
        RuleFor(x => x.Size).NotNull().WithMessage("Choose the size");
    }
}
