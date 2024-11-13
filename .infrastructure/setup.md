Commands for pipeline:

Previous command:
docker build -t nextstop-actions-runner:latest -f actions-runner.Dockerfile .

Updated command:
docker run -d --privileged --name nextstop-actions-runner:latest -e DOCKER_HOST=unix:///var/run/docker.sock -v /var/run/docker.sock:/var/run/docker.sock -ti actions-runner.Dockerfile .

Execute the following commands in container:
sudo chown root:docker /var/run/docker.sock
sudo chmod 660 /var/run/docker.sock

docker run --name nextstop-actions-runner -ti nextstop-actions-runner:latest
$ ./config.sh --url https://github.com/xxx/yyy --token XXXXXXXXXXXXXXXXXXXXXXXXXXXXX
$ ./run.sh