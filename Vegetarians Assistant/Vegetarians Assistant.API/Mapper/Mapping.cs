﻿using AutoMapper;
using Vegetarians_Assistant.Repo.Entity;
using Vegetarians_Assistant.Services.ModelView;

namespace Vegetarians_Assistant.API.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, UserView>().ReverseMap();
            CreateMap<User, LoginView>().ReverseMap();
            CreateMap<Article, ArticleView>().ReverseMap();
            CreateMap<ArticleView, Article>()
    .ForMember(dest => dest.ArticleImages, opt => opt.MapFrom(src => src.ArticleImages.Select(url => new ArticleImage { ImageUrl = url }).ToList()));
            CreateMap<Comment, CommentView>().ReverseMap();
            CreateMap<User, StaffView>().ReverseMap();
            CreateMap<Dish, DishView>().ReverseMap();
            CreateMap<Feedback, FeedbackView>().ReverseMap();
            CreateMap<UserMembership, UserMembershipView>().ReverseMap();
            CreateMap<MembershipTier, MembershipTierView>().ReverseMap();
            CreateMap<Cart, CartView>().ReverseMap();
            CreateMap<Cart, CartInfoView>().ReverseMap();
            CreateMap<User, DeliveryView>().ReverseMap();
            CreateMap<Order, OrderView>().ReverseMap();
            CreateMap<Follower, FollowerView>().ReverseMap();
            CreateMap<Following, FollowingView>().ReverseMap();
            CreateMap<FavoriteDish, FavoriteDishView>().ReverseMap();
            CreateMap<FavoriteDish, FavoriteView>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailView>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailInfo>().ReverseMap();
            CreateMap<NutritionCriterion, NutritionCriterionView>().ReverseMap();
            CreateMap<ArticleImage, ArticleImageView>().ReverseMap();
        }
    }
}
