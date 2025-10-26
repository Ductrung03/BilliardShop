# Controller Actions & ViewModels

This document outlines the primary controller actions and their associated ViewModels required to implement the user-facing features of the Billiard Shop.

## `HomeController`

- **`Index()`**: Displays the home page.
  - **ViewModel**: `HomeViewModel` (containing lists of featured products, new arrivals, etc.)

## `ProductController`

- **`Index(string categorySlug)`**: Displays the product listing page for a given category.
  - **ViewModel**: `ProductListViewModel` (containing a paginated list of `ProductSummaryViewModel`, filter options, and category information).
- **`Details(string productSlug)`**: Displays the detailed page for a single product.
  - **ViewModel**: `ProductDetailViewModel` (containing all product attributes, images, reviews, etc.).
- **`Search(string query)`**: Displays search results.
  - **ViewModel**: `ProductListViewModel` (similar to the category listing).

## `CartController`

- **`Index()`**: Displays the current shopping cart.
  - **ViewModel**: `CartViewModel` (containing a list of `CartItemViewModel` and order totals).
- **`AddToCart(int productId, int quantity)`**: Adds a product to the cart. This will likely be a POST request, possibly called via AJAX, and will return a JSON result (e.g., `{ success: true, newTotal: 123.45 }`).
- **`UpdateQuantity(int productId, int quantity)`**: Updates the quantity of an item in the cart.
- **`RemoveFromCart(int productId)`**: Removes an item from the cart.

## `CheckoutController`

- **`Index()`**: Displays the checkout page with forms for shipping and payment information.
  - **ViewModel**: `CheckoutViewModel` (containing shipping details, order summary, and available payment/shipping methods).
- **`PlaceOrder(CheckoutViewModel model)`**: Handles the submission of the checkout form (POST). On success, it creates the order and redirects to the `Confirmation` page. On failure, it redisplays the form with validation errors.
- **`Confirmation(int orderId)`**: Displays the order confirmation page after a successful checkout.
  - **ViewModel**: `OrderConfirmationViewModel` (containing the order number and a summary).

## `AccountController` (Future Enhancement)

- **`Reviews()`**: Displays reviews written by the user.
- **`Wishlist()`**: Displays the user's wishlist.

## Common ViewModels

- **`ProductSummaryViewModel`**: A subset of product data for use in listings (Name, Price, Image, Slug, Rating).
- **`CartItemViewModel`**: Represents a single line item in the shopping cart.
