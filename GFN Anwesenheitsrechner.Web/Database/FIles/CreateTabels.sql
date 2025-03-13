-- Create UsersList table if it doesn't exist
CREATE TABLE IF NOT EXISTS UsersList (
    UserID INTEGER PRIMARY KEY AUTOINCREMENT,  -- Auto-increment primary key
    Username VARCHAR(255) NOT NULL,            -- Username column
    Password VARCHAR(255) NOT NULL             -- Password column
);

-- Create PresenceList table if it doesn't exist
CREATE TABLE IF NOT EXISTS PresenceList (
    PresenceID INTEGER PRIMARY KEY AUTOINCREMENT,   -- Auto-incremented primary key
    UserID INTEGER NOT NULL,                        -- Foreign key referencing UsersList
    Date DATE,                                      -- Date of presence record
    HomeOffice INTEGER CHECK (HomeOffice IN (0, 1)) DEFAULT 0, -- Boolean as INTEGER
    LoginTime TIME,                             -- Time of login
    LogoutTime TIME,                            -- Time of logout
    CorrectionLogin TIME,                       -- Nullable corrected login time
    CorrectionLogout TIME,                      -- Nullable corrected logout time
    FOREIGN KEY (UserID) REFERENCES UsersList(UserID) ON DELETE CASCADE -- Cascade delete
);
