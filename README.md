# Tymish

A dotnet core web api with posgres.

## Dev Setup

### 1. Install tools
#### node 
```bash
$ node --version
v13.7.0
```
#### yarn
```bash
$ yarn --version
1.22.0
```
#### PostgreSQL - It doesn't need to have the ubuntu part
```bash
$ psql --version
psql (PostgreSQL) 10.12 (Ubuntu 10.12-0ubuntu0.18.04.1)
```
#### .NET Core SDK
```bash
$ dotnet --version
3.1.102
```

### 2. Setup database
```bash
$ sudo -i -u postgres                   # use postgres account
$ createuser --interactive --pwprompt   # create a user to use for VSCode and other GUI tools
# provide username and password         # Remember these for the connection string
```

### 3. Setup connection string with dotnet `secrets-manager`
```bash
$ echo '{
"ConnectionStrings:TymishContext": "Host=localhost;Port=5432;Database=Tymish;Username=<REPLACE>;Password=<REPLACE>;"
}' > ~/.microsoft/usersecrets/d2078994-b580-4445-aa97-ed51fbb20f6b/secrets.json
# make sure to replace <REPLACE> with your new postgres user name and password
```

### 4. Run Entity Framework Migrations
```bash
$ yarn build                              # ...
$ yarn add-migration <migration-name>     # <migration-name> can be 'init'
$ yarn update-db                          # updates the database
```

### 5. Run the WebApi
```bash
$ yarn start
# https://localhost:5001/swagger
```

## Snippets for development
### Drop database
* `sudo -i -u postgres`
* `psql`
* `\l`
* `drop database "Tymish";`

## Nice to haves (Future)
* GraphQL for data fetching