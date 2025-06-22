-- Create UrlInfo table
CREATE TABLE IF NOT EXISTS "UrlInfos" (
    "Id" SERIAL PRIMARY KEY,
    "OriginalUrl" TEXT,
    "ShortenedUrlId" VARCHAR(4),
    "CreatedAt" TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    CONSTRAINT uq_shortened_url_id UNIQUE ("ShortenedUrlId")
);

-- Create UrlStats table
CREATE TABLE IF NOT EXISTS "UrlStats" (
    "Id" SERIAL PRIMARY KEY,
    "UrlId" INTEGER NOT NULL,
    "CountsClicked" INTEGER NOT NULL DEFAULT 0,
    FOREIGN KEY ("UrlId") REFERENCES "UrlInfos"("Id") ON DELETE CASCADE
);

-- Optional: Index to speed up join queries
CREATE INDEX IF NOT EXISTS idx_urlstats_urlid ON "UrlStats" ("UrlId");
