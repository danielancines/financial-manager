# Commands

Image Creation: ```docker image build -t ghcr.io/danielancines/financial-manager-api:v1.0.0 .```
Container Run: ```docker container run --env DbUser=<DB-USER> --env DbPWd=<DB-PWD> -d -p 5095:80 test```
