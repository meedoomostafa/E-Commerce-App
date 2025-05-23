﻿using App.Models;
using App.Models.Models;
using App.Repositories.Configrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories.Database;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new AppUserModelConfigrations().Configure(modelBuilder.Entity<AppUser>());
        new CategoriesModelConfigrations().Configure(modelBuilder.Entity<Category>());
        new ProductModelConfigrations().Configure(modelBuilder.Entity<Product>());
        new ShoppingCartModelConfigrations().Configure(modelBuilder.Entity<ShoppingCart>());
        new CartItemModelConfigrations().Configure(modelBuilder.Entity<CartItem>());
        new ReviewModelConfigrations().Configure(modelBuilder.Entity<Review>());
        new WishListModelConfigrations().Configure(modelBuilder.Entity<Wishlist>());
        new WishListItemModelConfigrations().Configure(modelBuilder.Entity<WishlistItem>());
        new OrderItemModelConfigrations().Configure(modelBuilder.Entity<OrderItem>());
        new OrderModelConfigrations().Configure(modelBuilder.Entity<Order>());
    }
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Wishlist> Wishlists { get; set; } // Added
    public DbSet<WishlistItem> WishlistItems { get; set; } // Added
    
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Order> Orders { get; set; }
}
