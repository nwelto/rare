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
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
                      });
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

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
app.MapGet("/posts/all", () => Results.Ok(posts));

//CREATE POST
app.MapPost("/posts", (Posts post) =>
{
    post.Id = posts.Max(p => p.Id) + 1;
    posts.Add(post);
    return Results.Created($"/posts/{post.Id}", post);
});

//UPDATE POST
app.MapPut("/posts/{id}", (int id, Posts updatedPost) =>
{
    var post = posts.FirstOrDefault(p => p.Id == id);
    if (post == null)
    {
        return Results.NotFound($"Post with ID {id} not found.");
    }

    post.Title = updatedPost.Title;
    post.Content = updatedPost.Content;
    post.ImageUrl = updatedPost.ImageUrl;
    post.CategoryId = updatedPost.CategoryId;
    post.Approved = updatedPost.Approved;
    post.PublicationDate = updatedPost.PublicationDate;

    return Results.Ok(post);
});


//GET POST BY ID
app.MapGet("/posts/{id}", (int id) =>
{
    var post = posts.FirstOrDefault(p => p.Id == id);
    return post != null ? Results.Ok(post) : Results.NotFound();
});

//GET POST BY USER
app.MapGet("/posts/user/{userId}", (int userId) =>
{
    var userPosts = posts.Where(p => p.UserId == userId).ToList();
    if (userPosts == null || !userPosts.Any())
    {
        return Results.NotFound($"No posts found for user with ID {userId}.");
    }
    return Results.Ok(userPosts);
});

//DELETE POST
app.MapDelete("posts/{id}", (int id) =>
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
    var sortedTags = tags.OrderBy(tag => tag.Label).ToList();
    return sortedTags;
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

//Get Post Comments

app.MapGet("/posts/{postId}/comments/{commentId}", (int postId, int commentId) =>
{
    var comment = comments.FirstOrDefault(c => c.Id == commentId && c.PostId == postId);

    if (comment == null)
    {
        return Results.NotFound("Comment not found.");
    }
    return Results.Ok(comment);
});

//Get Subscribed Posts

app.MapGet("/subscribed-posts/{followerId}", (int followerId) =>
{
    var subscribedPosts = (from sub in subscriptions
                           join post in posts on sub.AuthorId equals post.UserId
                           where sub.FollowerId == followerId
                           select post).ToList();

    return Results.Ok(subscribedPosts);
});

//Get Categories

app.MapGet("/categories", () =>
{
    return Results.Ok(categories);
});

//Get Posts by Category

app.MapGet("/posts", (int categoryId) =>
{
    var filteredPosts = posts.Where(p => p.CategoryId == categoryId).ToList();

    return Results.Ok(filteredPosts);
});

//Post a Category

app.MapPost("/categories", (Categories category) =>
{
    if (category == null)
    {
        return Results.BadRequest("Category data is invalid.");
    }
    categories.Add(category);
    return Results.Ok("Category created successfully.");
});

// DELETE CATEGORY
app.MapDelete("/categories/{id}", (int id) =>
{
    var categoryToDelete = categories.FirstOrDefault(c => c.Id == id);
    if (categoryToDelete == null)
    {
        return Results.NotFound();
    };
    categories.Remove(categoryToDelete);
    return Results.Ok();
});

// GET TAGS ASSOCIATED WITH POSTS
app.MapGet("/posts/{id}/tags", (int id) =>
{
     Posts post = posts.FirstOrDefault(p => p.Id == id);

    if (post == null)
    {
        return Results.NotFound("Post not found!");
    }

    List<int> tagIds = PostTagList
    .Where(pt => pt.PostId == id)
    .Select(pt => pt.TagId)
    .ToList();
    List<Tags> associatedTags = tags
    .Where(t => tagIds.Contains(t.Id)).ToList();

    return Results.Ok(associatedTags);
});

// GET POSTS BASED ON TAGS
app.MapGet("/tags/{id}/posts", (int id) =>
{
    Tags tag = tags.FirstOrDefault(t => t.Id == id);

    if (tag == null)
    {
        return Results.NotFound("Tag not found!");
    }

    var postIds = PostTagList
    .Where(pt => pt.TagId == id)
    .Select(pt => pt.PostId);
    var assignedPosts = posts
    .Where(p => postIds.Contains(p.Id))
    .ToList();
    foreach (var post in assignedPosts)
    {
        var tagIds = PostTagList
        .Where(pt => pt.PostId == post.Id)
        .Select(pt => pt.TagId);
        var postTags = tags
        .Where(t => tagIds.Contains(t.Id)).ToList();

        post.PostTags = postTags.Select(t => new PostTags { Id = t.Id, PostId = post.Id, TagId = t.Id }).ToList();
    }

    return Results.Ok(assignedPosts);
});

// EDIT TAGS ON POSTS
app.MapPut("/posts/{postId}/tags", (int postId, List<int> tagIds) =>
{
    Posts postToUpdate = posts.FirstOrDefault(p => p.Id == postId);
    if (postToUpdate == null)
    {
        return Results.NotFound("Post not found.");
    }

    PostTagList.RemoveAll(pt => pt.PostId == postId);
    PostTagList.AddRange(tagIds.Select(tagId => new PostTags
    {
        Id = PostTagList.Count + 1,
        PostId = postId,
        TagId = tagId
    }));

    return Results.Ok("Tags updated successfully!");
});

// ADD TAGS TO NEW POST
app.MapPost("/posts/{postId}/tags", (int postId, int tagId) =>
{
    PostTags postTag = new PostTags
    {
        Id = PostTagList.Max(postTag => postTag.Id) + 1,
        PostId = postId,
        TagId = tagId,
    };
    PostTagList.Add(postTag);
    return Results.Ok(postTag);
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

// REACTIONS - GET REACTIONS

app.MapGet("/reactions", () =>
{
    return Results.Ok(reactions);
});

//REACTIONS - GET REACTIONS BY ID

app.MapGet("/reactions/{reactionId}", (int reactionId) =>
{
    var reaction = reactions.FirstOrDefault(r => r.Id == reactionId);

    if (reaction == null)
    {
        return Results.NotFound("Reaction not found.");
    }
    return Results.Ok(reaction);
});

//GET POSTREACTIONS

app.MapGet("/postreactions", () =>
{
    return Results.Ok(postReactions);
});

//GET REACTIONS by POST

app.MapGet("/posts/{postId}/reactions", (int postId) =>
{
    var ReactionsForPost = postReactions.Where(pr => pr.PostId == postId).ToList();

    return Results.Ok(ReactionsForPost);
});

// CREATE POST REACTIONS
app.MapPost("/posts/reactions/create", (PostReactions postReaction) =>
{
    postReaction.Id = postReactions.Max(pr => pr.Id) + 1;
    postReactions.Add(postReaction);
    return postReaction;
});

// DELETE POST REACTIONS
app.MapDelete("/posts/{postId}/reactions/{reactionId}", (int postId, int reactionId) =>
{
    var reactionToDelete = postReactions.FirstOrDefault(pr => pr.PostId == postId && pr.Id == reactionId);
    if (reactionToDelete == null)
    {
        return Results.NotFound("Reaction not found!");
    }

    postReactions.Remove(reactionToDelete);
    return Results.Ok("Reaction deleted!");
});

app.Run();