## WebApplication1 (CRUD-EXAMPLE)

##Getting started

1. Clone the repository
```
git clone "https://github.com/javier-goma/WebApplication1.git"
```

### Prerequisites
* Docker/DockerMachine

#### Building the docker image
To be able to run our application in a docker container, we should build the docker image with the next commands:
```sh
cd WebApplication1
docker build -t webapp/rest .
```
Pay attention that the tag for our image is called "webapp/rest"

#### Running the container
Since the image is ready, follow the next command to run a docker container with our application
```
docker run -p 8080:80 webapp/rest .
```

The API is now reachable in the next address 
````ash
http://localhost:8080/
````
