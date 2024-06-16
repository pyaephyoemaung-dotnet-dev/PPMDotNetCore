$(document).ready(function() {
    const cartItems = [
        { name: 'Item 1', price: 10.00, quantity: 0, total: 0.00 },
        { name: 'Item 2', price: 20.00, quantity: 0, total: 0.00 },
        { name: 'Item 3', price: 30.00, quantity: 0, total: 0.00 },
        { name: 'Item 4', price: 40.00, quantity: 0, total: 0.00 },
        { name: 'Item 5', price: 50.00, quantity: 0, total: 0.00 },
        { name: 'Item 6', price: 60.00, quantity: 0, total: 0.00 },
        { name: 'Item 7', price: 70.00, quantity: 0, total: 0.00 },
        { name: 'Item 8', price: 80.00, quantity: 0, total: 0.00 },
        { name: 'Item 9', price: 90.00, quantity: 0, total: 0.00 },
        { name: 'Item 10', price: 100.00, quantity: 0, total: 0.00 }
    ];
    productChart();

    function productChart() {
        const cartTable = $('#cart-items');
        cartTable.empty();

        let totalPrice = 0;

        cartItems.forEach((item, index) => {
            totalPrice += item.total;

            const row = `
                <tr>
                    <td class="px-6 py-4 whitespace-nowrap">${item.name}</td>
                    <td class="px-6 py-4 whitespace-nowrap">$${item.price.toFixed(2)}</td>
                    <td class="px-6 py-4 whitespace-nowrap">
                        <input type="number" value="${item.quantity}" min="1" data-index="${index}" class="quantity-input mt-1 block px-3 py-2 border border-gray-300 rounded-md shadow-sm ">
                    </td>
                    <td class="px-6 py-4 whitespace-nowrap">$${item.total.toFixed(2)}</td>
                    <td class="px-6 py-4 whitespace-nowrap">
                        <button data-index="${index}" class="increase-button inline-flex justify-center py-2 px-4 mr-2 border border-transparent shadow-sm text-sm font-medium rounded-md text-white bg-blue-600 hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-500"><i class="fas fa-plus"></i></button>
                        <button data-index="${index}" class="remove-button inline-flex justify-center py-2 px-4 border border-transparent shadow-sm text-sm font-medium rounded-md text-white bg-red-600 hover:bg-red-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-red-500"><i class="fas fa-trash"></i></button>
                    </td>
                </tr>
            `;
            cartTable.append(row);
        });

        $('#total-price').text(totalPrice.toFixed(2));
        controlChart();
    }
    function controlChart() {
        $('.increase-button').click(increaseQuantity);
        $('.remove-button').click(removeItem);
        $('.quantity-input').change(updateQuantity);
    }

    function increaseQuantity(event) {
        const index = $(event.target).closest('button').data('index');
        cartItems[index].quantity += 1;
        cartItems[index].total = cartItems[index].price * cartItems[index].quantity;
        productChart();
    }

    function removeItem(event) {
        const index = $(event.target).closest('button').data('index');
        cartItems.splice(index, 1);
        productChart();
    }


    function updateQuantity(event) {
        const index = $(event.target).data('index');
        const quantity = parseInt($(event.target).val());
        cartItems[index].quantity = quantity;
        cartItems[index].total = cartItems[index].price * quantity;
        productChart();
    }
});
