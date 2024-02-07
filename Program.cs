using Microsoft.Extensions.Hosting;
using rare.Models;
using System.Xml.Linq;

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
        CreatedOn = new DateTime(2024,01,01),
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
        CreatedOn = new DateTime(2024,01,02),
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
        CreatedOn = new DateTime(2024,01,03),
        Active = true
    }
};

List<Posts> posts = new List<Posts>
{
    new Posts()
    {
        Id = 1,
        UserId = 1,
        CategoryId = 1,
        Title = "The Future of Technology in Literature",
        PublicationDate = new DateTime(2024,02,05),
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
        PublicationDate = new DateTime(2024,02,06),
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
        PublicationDate = new DateTime(2024,02,07),
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
      Id = 4,

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

List<PostReactions> postReactions = new List<PostReactions>
{
    new PostReactions()
    {
        Id = 1,
        ReactionId = 1,
        UserId = 2,
        PostId = 1
    },
    new PostReactions()
    {
        Id = 2,
        ReactionId = 2,
        UserId = 1,
        PostId = 2
    },
    new PostReactions()
    {
        Id = 3,
        ReactionId = 3,
        UserId = 3,
        PostId = 3
    }
};

List<Comments> comments = new List<Comments>
{
    new Comments()
    {
        Id = 1,
        AuthorId = 1,
        PostId = 1,
        Content = "Really enjoyed this article! It gave me a lot to think about."
    },
    new Comments()
    {
        Id = 2,
        AuthorId = 2,
        PostId = 2,
        Content = "Wonderful insights on classic literature. Thanks for sharing!"
    },
    new Comments()
    {
        Id = 3,
        AuthorId = 3,
        PostId = 3,
        Content = "Your writing transported me to the places you described. Beautiful!"
    }
};

List<Categories> categories = new List<Categories>
{
    new Categories()
    {
        Id = 1,
        Label = "Technology"
    },
    new Categories()
    {
        Id = 2,
        Label = "Classics"
    },
    new Categories()
    {
        Id = 3,
        Label = "Travel"
    }
};

List<Reactions> reactions = new List<Reactions>
{
    new Reactions()
    {
        Id = 1,
        Emoji = ":+1:"
    },
    new Reactions()
    {
        Id = 2,
        Emoji = ":heart:"
    },
    new Reactions()
    {
        Id = 3,
        Emoji = ":joy:"
    }
};

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// GET - ALL USERS
app.MapGet("/users", () => 
{
    return users;
});

// GET USER BY ID - OBTAINING USER DETAILS
app.MapGet("/users/{id}", (int id) => {
    Users user = users.FirstOrDefault(u => u.Id == id);
    if (user == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(user);
});

// GET POST
app.MapGet("/api/posts", () => Results.Ok(posts));

//GET POST BY ID
app.MapGet("/api/posts/{id}", (int id) =>
{
    var post = posts.FirstOrDefault(p => p.Id == id);
    return post != null ? Results.Ok(post) : Results.NotFound();
});

//DELETE POST
app.MapDelete("/api/posts/{id}", (int id) =>
{
    var post = posts.FirstOrDefault(p => p.Id == id);
    if (post == null) return Results.NotFound();

    posts.Remove(post);
    return Results.Ok(new { message = "Post deleted successfully." });
});


//POST Comment to POST
app.MapPost("/posts/{postId}/comments", (int postId, Comments comment) =>
{

    if (comment == null)
    {
        return Results.BadRequest("Comment data is invalid.");
    }

    comments.Add(comment);

    return Results.Ok("Comment added successfully.");
});

//DELETE a Comment

app.MapDelete("/comments/{commentId}", (int commentId) =>
{
    var commentToDelete = comments.FirstOrDefault(c => c.Id == commentId);

    if (commentToDelete == null)
    {
        return Results.NotFound("Comment not found.");
    }

    comments.Remove(commentToDelete);

    return Results.Ok("Comment deleted successfully.");
});

// GET ALL TAGS
app.MapGet("/tags", () =>
{
    return tags;
});

// CREATE/POST TAGS
app.MapPost("/tags", (Tags tag) =>
{
    tag.Id = tags.Max(t => t.Id) + 1;
    tags.Add(tag);
    return tag;
});

// EDIT/PUT TAGS
app.MapPut("tags/{id}", (int id, Tags tag) =>
{
    Tags tagToUpdate = tags.FirstOrDefault(t => t.Id == id);
    int tagIndex = tags.IndexOf(tagToUpdate);
    if (tagToUpdate == null)
    {
        return Results.NotFound();
    }
    if (id != tag.Id)
    {
        return Results.BadRequest();
    }
    tags[tagIndex] = tag;
    return Results.Ok();
});


// DELETE TAGS
app.MapDelete("/tags/{id}", (int id) =>
{
    Tags tag = tags.FirstOrDefault(t => t.Id == id);
    if (tag == null)
    {
        return Results.NotFound();
    }
    tags.Remove(tag);
    return Results.Ok(tag);
});


// GET SUBSCRIPTIONS BY USER
app.MapGet("/subscription/{id}", (int id) => {
    var subs = subscriptions.Where(u => u.FollowerId == id).ToList();
    if (subs == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(subs);
});


// POST - ASSOCIATE SUBSCRIPTION 
app.MapPost("/subscription", (Subscriptions subscription) =>
{
    subscription.Id = subscriptions.Max(st => st.Id) + 1;
    subscription.CreatedOn = DateTime.Now;
    subscriptions.Add(subscription);
    return subscription;
});

// DELETE - DISASSOCIATE SUBSCRIPTION
app.MapDelete("/subscription/{id}", (int id) =>
{
    Subscriptions subscriptionToDelete = subscriptions.FirstOrDefault(sub => sub.Id == id);
    if (subscriptionToDelete == null)
    {
        return Results.NotFound();
    };
    subscriptions.Remove(subscriptionToDelete);
    return Results.Ok();
});


app.Run();