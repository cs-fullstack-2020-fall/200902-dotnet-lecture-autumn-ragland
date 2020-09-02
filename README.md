# 200902-dotnet-lecture
Data Annotations and eager loading

## Use the provided starter MVC project
* Run and apply migrations
* Verify database created
* Verify application launches

### Authors and Posts

#### Author
```
id - int, required
FirstName - string, required
LastName - string, required
BlogPosts - List<BlogPost>
```

#### BlogPost
```
id - int, required
PostTitle - string, required, min length 10, max length 100
PostText - string, required
PostRating - int, range 1 - 5
```

### Implement Create and Read endpoints
* Adding a new post should require an Author to tie the post to
  * Do an author lookup on ID passed in, return error if author not found
* Get Author endpoint should also return all posts for each Author
* Return list of validations failures on failure

### Extra
Use this method for handling validation errors.
```
        public static List<string> GetErrorListFromModelState
                                              (ModelStateDictionary modelState)
        {
            var query = from state in modelState.Values
                        from error in state.Errors
                        select error.ErrorMessage;

            var errorList = query.ToList();
            return errorList;
        }
```        
