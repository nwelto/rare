using Microsoft.Extensions.Hosting;
using rare.Models;

List<Users> users = new List<Users>
{
    new Users()
    {
        Id = 1,
        FirstName = "John",
        LastName = "Doe",
        Email = "john.doe@example.com",
        Bio = "Avid reader and writer.",
        Username = "johndoe",
        Password = "hashed_password1",
        ProfileImageUrl = "http://example.com/images/johndoe.png",
        CreatedOn = "2024-01-01",
        Active = true
    },
    new Users()
    {
        Id = 2,
        FirstName = "Jane",
        LastName = "Smith",
        Email = "jane.smith@example.com",
        Bio = "Novelist and blogger.",
        Username = "janesmith",
        Password = "hashed_password2",
        ProfileImageUrl = "http://example.com/images/janesmith.png",
        CreatedOn = "2024-01-02",
        Active = true
    },
    new Users()
    {
        Id = 3,
        FirstName = "Emily",
        LastName = "Brown",
        Email = "emily.brown@example.com",
        Bio = "Freelance journalist and editor.",
        Username = "emilyb",
        Password = "hashed_password3",
        ProfileImageUrl = "http://example.com/images/emilyb.png",
        CreatedOn = "2024-01-03",
        Active = true
    }
};

List<Post> posts = new List<Post>
{
    new Posts()
    {
        Id = 1,
        UserId = 1,
        CategoryId = 1,
        Title = "The Future of Technology in Literature",
        PublicationDate = "2024-02-05",
        ImageUrl = "http://example.com/images/post1.png",
        Content = "An exploration of how technology influences modern storytelling...",
        Approved = true
    },
    new Posts()
    {
        Id = 2,
        UserId = 2,
        CategoryId = 2,
        Title = "Rediscovering Classic Novels",
        PublicationDate = "2024-02-06",
        ImageUrl = "http://example.com/images/post2.png",
        Content = "A personal journey through the classics of literature...",
        Approved = true
    },
    new Posts()
    {
        Id = 3,
        UserId = 3,
        CategoryId = 3,
        Title = "The Art of Travel Writing",
        PublicationDate = "2024-02-07",
        ImageUrl = "http://example.com/images/post3.png",
        Content = "Crafting engaging narratives from travel experiences...",
        Approved = true
    }
};

List<Tags> tags = new List<Tags>
{
    new Tags()
    {
      Id = 1,
      Label = "Informative"
    },

    new Tags()
    {
      Id = 2,
      Label = "Quick Read"
    },
    new Tags()
    {
      Id = 3,
      Label = "Tips"
    },
    new Tags()
    {
      Id = 4

      Label = "Creativity"
    },
};

List<PostTags> PostTagList = new List<PostTags>
{
    new PostTags()
    {
      Id = 1,
      TagId = 1,
      PostId = 1
    },
    new PostTags()
    {
      Id = 2,
      TagId = 2,
      PostId = 2
    },
    new PostTags()
    {
      Id = 3,
      TagId = 3,
      PostId = 3
    },
    new PostTags()
    {
      Id = 4,
      TagId = 4,
      PostId = 4
    }
};

List<Subscriptions> subscriptions = new List<Subscriptions>
{
    new Subscriptions()
    {
      Id = 1,
      FollowerId = 1,
      AuthorId = 1,
      CreatedOn =  new DateTime(2023, 11, 20)
    },
    new Subscriptions()
    {
      Id = 2,
      FollowerId = 2,
      AuthorId = 2,
      CreatedOn =  new DateTime(2023, 12, 07)
    },
    new Subscriptions()
    {
      Id = 3,
      FollowerId = 3,
      AuthorId = 3,
      CreatedOn =  new DateTime(2024, 02, 06)
    }
};
