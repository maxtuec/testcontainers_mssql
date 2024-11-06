Commands for pipeline:

 docker build -t nextstop-actions-runner:latest -f actions-runner.Dockerfile .

docker run --name nextstop-actions-runner -ti nextstop-actions-runner:latest
$ ./config.sh --url https://github.com/xxx/yyy --token XXXXXXXXXXXXXXXXXXXXXXXXXXXXX
$ ./run.sh