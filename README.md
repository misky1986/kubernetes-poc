# Kubernetes-poc
Before we get started lest start up the Kubernetes Dashboard.

Reference: https://kubernetes.io/docs/tasks/access-application-cluster/web-ui-dashboard/

## Dashboard
The Dashboard UI is not deployed by default. To deploy it, run the following command:

```kubectl apply -f https://raw.githubusercontent.com/kubernetes/dashboard/v2.0.0-beta4/aio/deploy/recommended.yaml```

## Accessing the Dashboard UI
To protect your cluster data, Dashboard deploys with a minimal RBAC configuration by default. Currently, Dashboard only supports logging in with a Bearer Token. 

### Create Service Account
Run the following command: ```kubectl apply -f k8s\dashboard\dashboard-adminuser.yaml```

### Create Cluster Role Binding
Run the following command: ```kubectl apply -f k8s\dashboard\dashboard-cluster-role-binding.yaml```

### Create Beare Token

The Bearer Token can be obtained in some different ways

#### PowerShell
##### Using Config
$TOKEN=((kubectl -n kube-system describe secret default | Select-String "token:") -split " +")[1]
kubectl config set-credentials docker-for-desktop --token="${TOKEN}"
User "docker-for-desktop" set.

##### Using Token
$TOKEN=((kubectl -n kube-system describe secret default | Select-String "token:") -split " +")[1]

In PowerShell write: ```$TOKEN``` and copy the token.

#### Linux (WLS)

### Start Kubernetes Dashboard
* In your favorite prompt write: ```kutectl proxy```
* Open a browser and paste in the following: http://localhost:8001/api/v1/namespaces/kubernetes-dashboard/services/https:kubernetes-dashboard:/proxy/
* Select Token and paste in the token generated from before

Viola, now Kubernetes Dashboard is running :)