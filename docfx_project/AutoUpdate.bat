SET PPath=%~dp0
winscp /console /command "option batch continue" "option confirm off" "open sftp://uploader:an123456@anw.noip.cn:22" "option transfer binary" "put %PPath%\_site\* /var/www/html/doc/gridsystem/" "exit" /log=log_file.txt