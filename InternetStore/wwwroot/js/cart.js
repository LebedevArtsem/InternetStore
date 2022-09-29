$(document).ready(function()
{
	function initQty()
	{
		if($('.product_quantity').length)
		{
			var qtys = $('.product_quantity');

			qtys.each(function()
			{
				var qty = $(this);
				var sub = qty.find('.qty_sub');
				var add = qty.find('.qty_add');
				var num = qty.find('.product_num');
				var original;
				var newValue;

				sub.on('click', function()
				{
					original = parseFloat(qty.find('.product_num').text());
					if(original > 0)
						{
							newValue = original - 1;
						}
					num.text(newValue);
				});

				add.on('click', function()
				{
					original = parseFloat(qty.find('.product_num').text());
					newValue = original + 1;
					num.text(newValue);
				});
			});
		}
	}

});