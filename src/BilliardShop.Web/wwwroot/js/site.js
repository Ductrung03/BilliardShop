function addToCart(productId, quantity) {
    $.ajax({
        url: '/Cart/AddToCart',
        type: 'POST',
        data: {
            productId: productId,
            quantity: quantity
        },
        success: function (response) {
            if (response.success) {
                // Update cart drawer
                $('#CartDrawer-CartItems').html(response.html);

                // Update cart count bubble
                $('.cart-count-bubble span[aria-hidden="true"]').text(response.count);
                $('.cart-count-bubble .visually-hidden').text(response.count + ' items');

                // Update subtotal
                $('.totals__subtotal-value').text(response.subTotal.toLocaleString('en-US', { style: 'currency', currency: 'USD' }));

                // Show cart drawer
                $('cart-drawer').addClass('active');
                $('body').addClass('overflow-hidden-tablet');
            } else {
                alert(response.message);
            }
        },
        error: function () {
            alert('An error occurred while adding the item to the cart.');
        }
    });
}