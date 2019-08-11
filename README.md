# CRUD com ASP.NET Core 2.2 e SQLServer Express 
 
App simples para ser hospedado em servidores Linux (debian-ubuntu) para demonstrar a utilização do ASP.NET Core e o SQLServer na plataforma UNIX.
*Arquivos de apoio(confg app & confg service) disponíveis em*: 
[https://github.com/glennc/AspNetCoreConfigFiles](https://github.com/glennc/AspNetCoreConfigFiles)

## Configurações para hospedagem Linux

#### Servidor Nginx(proxy reverso) e Kestrel(do próprio asp.net):

* publicar em: /var/www
* arquivo do servico Nginx: /lib/systemd/system/nginx.service
* caminho de confg do app: /etc/nginx/sites-available/default
* arquivos de servicos: /lib/systemd/system/

## Passo a passo:

1. Configurar Proxy reverso no arquivo /etc/nginx/sites-available/default

2. Apos o publish na pasta /var/www criar o arquivo de servico em /lib/systemd/system/

3. Gerar o certificado ssl e colocar em /usr/share/ca-certificates (ou modif. em appsetings.json)

4. Reiniciar o Nginx (sudo Nginx -s reload)

5. Reiniciar o systemd (sudo systemctl deamon-reload)

### Configurações básicas de proxy reverso _não usar em produção!_:

server {
    listen 80;
    location / {
        proxy_pass http://localhost:5000;
        proxy_http_version 1.1;
        proxy_set_header Upgrade $http_upgrade;
        proxy_set_header Connection keep-alive;
        proxy_set_header Host $host;
        proxy_cache_bypass $http_upgrade;
    }
}

### Configuracoes simples de servico:

#Simple starter config
[Unit]
#80 char maximum
Description=Sample application.

[Service]
#Simple is the default, and as such this could be omitted.
Type=simple
WorkingDirectory=/var/www/webapp
ExecStart=/usr/bin/dotnet /var/www/webapp/sampleApp.dll
User=web

[Install]
#options are graphical, for GUIs, or multi-user for everthing else.
WantedBy=multi-user.target

### Configuracoes simples de socket:

#Simple starter config
[Unit]
#80 char maximum
Description=Sample application.

[Service]
#Simple is the default, and as such this could be omitted.
Type=simple
Environment="ASPNETCORE_URLS=http://unix:/tmp/sampleapp.sock"
WorkingDirectory=/var/www/webapp
ExecStart=/usr/bin/dotnet /var/www/webapp/sampleApp.dll
User=web

[Install]
#options are graphical, for GUIs, or multi-user for everthing else.
WantedBy=multi-user.target




