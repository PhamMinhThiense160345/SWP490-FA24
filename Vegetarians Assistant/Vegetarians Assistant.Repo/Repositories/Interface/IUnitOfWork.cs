﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vegetarians_Assistant.Repo.Entity;

namespace Vegetarians_Assistant.Repo.Repositories.Interface
{
    public interface IUnitOfWork
    {
        IGenericRepository<Article> ArticleRepository { get; }
        IGenericRepository<ArticleImage> ArticleImageRepository { get; }
        IGenericRepository<ArticleLike> ArticleLikeRepository { get; }
        IGenericRepository<ArticleBody> ArticleBodyRepository { get; }
        IGenericRepository<Comment> CommentRepository { get; }
        IGenericRepository<CommentImage> CommentImageRepository { get; }
        IGenericRepository<DietaryPreference> DietaryPreferenceRepository { get; }
        IGenericRepository<Dish> DishRepository { get; }
        IGenericRepository<FavoriteDish> FavoriteDishRepository { get; }
        IGenericRepository<Feedback> FeedbackRepository { get; }
        IGenericRepository<FixedMenu> FixedMenuRepository { get; }
        IGenericRepository<FixedMenuItem> FixedMenuItemRepository { get; }
        IGenericRepository<Follower> FollowerRepository { get; }
        IGenericRepository<Following> FollowingRepository { get; }
        IGenericRepository<HealthRecord> HealthRecordRepository { get; }
        IGenericRepository<MembershipTier> MembershipTierRepository { get; }
        IGenericRepository<Menu> MenuRepository { get; }
        IGenericRepository<MenuDish> MenuDishRepository { get; }
        IGenericRepository<Notification> NotificationRepository { get; }
        IGenericRepository<NotificationSetting> NotificationSettingRepository { get; }
        IGenericRepository<NotificationType> NotificationTypeRepository { get; }
        IGenericRepository<NutritionalInfo> NutritionalInfoRepository { get; }
        IGenericRepository<NutritionCriterion> NutritionCriterionRepository { get; }
        IGenericRepository<Order> OrderRepository { get; }
        IGenericRepository<OrderDetail> OrderDetailRepository { get; }
        IGenericRepository<PaymentDetail> PaymentDetailRepository { get; }
        IGenericRepository<PaymentMethod> PaymentMethodRepository { get; }
        IGenericRepository<Restaurant> RestaurantRepository { get; }
        IGenericRepository<Role> RoleRepository { get; }
        IGenericRepository<Status> StatusRepository { get; }
        IGenericRepository<TotalNutritionDish> TotalNutritionDishRepository { get; }
        IGenericRepository<UsersNutritionCriterion> UsersNutritionCriterionRepository { get; }
        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<UserDeviceToken> UserDeviceTokenRepository { get; }
        IGenericRepository<UserMembership> UserMembershipRepository { get; }
        IGenericRepository<Cart> CartRepository { get; }
        IGenericRepository<Ingredient> IngredientRepository { get; }
        IGenericRepository<DishIngredient> DishIngredientRepository { get; }
        IGenericRepository<InvalidWord> InvalidWordRepository { get; }
        IGenericRepository<DiscountHistory> DiscountHistoryRepository { get; }
        IGenericRepository<Shipping> ShippingRepository { get; }
        Task SaveAsync();
    }
}
