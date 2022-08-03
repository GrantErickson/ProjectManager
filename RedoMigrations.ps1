$name= $args[0]

if ($name -eq $null -or $name -eq ""){
  $name = "Initial";
}

write-host "Rolling back all migrations and creating a migration called '$name'"

cd *.data
dotnet ef database update 0
dotnet ef migrations remove
dotnet ef migrations add $name

write-host "Running 'dotnet coalesce'"
cd ../*.web
dotnet coalesce

cd ..