using AutoMapper;
using Application.Author;
using Application.Author.Commands.EditAuthorCommand;
using Application.Book;
using Application.Book.Commands.EditBookCommand;
using Application.Category;
using Application.Category.Commands.EditCategoryCommand;
using Application.Publisher;
using Application.Publisher.Commands.EditPublisherCommand;
using Application.Review;
using Application.Category.Commands.CreateCategoryCommand;
using Application.Book.Commands.CreateBookCommand;
using Application.Publisher.Commands.CreatePublisherCommand;
using Application.Review.Commands.CreateReviewCommand;
using Application.Author.Commands.CreateAuthorCommand;

namespace Application.Mappings;

public class BookRentalSystemMappingProfile : Profile
{
    public BookRentalSystemMappingProfile()
    {
        CreateMap<AuthorDto, Core.Entities.Author>().ReverseMap();
        CreateMap<CreateAuthorCommand, Core.Entities.Author>();
        CreateMap<EditAuthorCommand, AuthorDto>().ReverseMap();

        CreateMap<ReviewDto, Core.Entities.Review>().ReverseMap();
        CreateMap<CreateReviewCommand, Core.Entities.Review>();

        CreateMap<PublisherDto, Core.Entities.Publisher>().ReverseMap();
        CreateMap<CreatePublisherCommand, Core.Entities.Publisher>();
        CreateMap<EditPublisherCommand, PublisherDto>().ReverseMap();

        CreateMap<BookDto, Core.Entities.Book>().ReverseMap();
        CreateMap<CreateBookCommand, Core.Entities.Book>();
        CreateMap<EditBookCommand, BookDto>().ReverseMap();

        CreateMap<CategoryDto, Core.Entities.Category>().ReverseMap();
        CreateMap<CreateCategoryCommand, Core.Entities.Category>();
        CreateMap<EditCategoryCommand, CategoryDto>().ReverseMap();
    }
}