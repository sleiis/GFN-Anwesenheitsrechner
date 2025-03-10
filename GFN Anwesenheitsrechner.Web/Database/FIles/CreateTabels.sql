-- Check if UsersList table exists and create it if it doesn't
CREATE TABLE IF NOT EXISTS UsersList (
    UserID INT PRIMARY KEY,          -- UserID as the primary key
    Username NOT NULL VARCHAR(255),           -- Username 
    Password NOT NULL VARCHAR(255)            -- Password 
);

-- Check if PresenceList table exists and create it if it doesn't
CREATE TABLE IF NOT EXISTS PresenceList (
    PresenceID INTEGER PRIMARY KEY AUTOINCREMENT,   -- Auto-incremented primary key for each record
    UserID NOT NULL INT,                            -- Foreign key referencing the UserID in UsersList
    Date DATE,                                      -- Date of presence record
    HomeOffice BOOLEAN,                             -- Indicates if the user was working from home
    LoginTime DATETIME,                             -- Time when the user logged in
    LogoutTime DATETIME,                            -- Time when the user logged out
    CorrectionLogin DATETIME,                       -- Nullable, corrected login time (if any)
    CorrectionLogout DATETIME,                      -- Nullable, corrected logout time (if any)
    FOREIGN KEY (UserID) REFERENCES UsersList(UserID) -- Foreign key constraint
);
