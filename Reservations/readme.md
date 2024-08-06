﻿- assuming provider entering specific availabilities rather than selecting from 15-minute increments
- wasn't able to get to unit testing
    - test basic CRUD
    - test availability conditions
- would rather not use EF. did so for speed and in-memory implementation. would rather have gone postgres + dapper. good news is that it's abstract enough to allow for easy replacement of the repository internals without affecting business logic
- EF usage forces referential integrity checks. would be more performant without them, simply relying on foreign key conditions
- wasn't able to finish containerizing
- the swagger parameter definitions incorrectly read as required in some cases