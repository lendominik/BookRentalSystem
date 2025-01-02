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

namespace Application.Mappings;

public class BookRentalSystemMappingProfile : Profile
{
    public BookRentalSystemMappingProfile()
    {
        CreateMap<AuthorDto, Core.Entities.Author>().ReverseMap();
        CreateMap<ReviewDto, Core.Entities.Review>().ReverseMap();
        CreateMap<PublisherDto, Core.Entities.Publisher>().ReverseMap();
        CreateMap<BookDto, Core.Entities.Book>().ReverseMap();
        CreateMap<CategoryDto, Core.Entities.Category>().ReverseMap();

        CreateMap<EditCategoryCommand, Core.Entities.Category>();
        CreateMap<EditAuthorCommand, Core.Entities.Author>();
        CreateMap<EditPublisherCommand, Core.Entities.Publisher>();
        CreateMap<EditBookCommand, Core.Entities.Book>();
    }
}