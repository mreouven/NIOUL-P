pipeline {
    agent { docker { image 'mcr.microsoft.com/dotnet/core/sdk:2.2-alpine' } }
    environment {HOME = '/tmp'} 
    stages {
    stage('Git') {
		
      // Get some code from a GitHub repository
      steps{
          git 'https://github.com/mreouven-study/NIOUL-P.git'
      }
	 
   }
    stage('Dotnet Restore'){
        steps{
        sh "dotnet restore"
        }
    }
	stage('Example') {
            steps {
                echo "Running ${env.BUILD_ID} on ${env.JENKINS_URL}"
            }
       }

    stage('Build'){
          steps{
				C:\Program Files (x86)\Jenkins\workspace\DQ
               sh "dotnet build WebApplication3.sln"
               }
    }
    stage('Run Tests'){
          steps{
               sh "dotnet test"
          }
    }
}
}