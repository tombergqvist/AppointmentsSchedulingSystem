export let getAPI = (name, callback) => {
    fetch('https://localhost:44392/api/appointment?name=' + name, {
        method: 'GET'
    })
        .then(response => {
            if (response.status === 200) {
                return response.json()
            } else {
                throw new Error('status: '+ response.status)
            }
        })
        .then(data => callback(data))
        .catch((error) => {
            alert('Could not get - '+ error)
        })
}

export let importAPI = (callback) => {
    fetch('https://localhost:44392/api/appointment/Import', {
        method: 'POST'
    })
        .then(response => response.text())
        .then(data => callback(data))
}

export let deleteAPI = (id, callback) => {
    fetch('https://localhost:44392/api/appointment/?id=' + id, {
        method: 'DELETE'
    })
        .then(response => response.text())
        .then(data => callback(data))
}

export let updateAPI = (id, name, phone, email, start, end, date, callback) => {
    fetch('https://localhost:44392/api/appointment/?id=' + id, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            "name": name,
            "email": email,
            "phoneNumber": phone,
            "startTime": start,
            "endTime": end,
            "date": date
        })
    })
        .then(response => response.text())
        .then(data => callback(data))
}

export let addAPI = (name, phone, email, start, end, date, callback) => {
    console.log(name, phone, email, start, end, date)
    fetch('https://localhost:44392/api/appointment/', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            "name": name,
            "email": email,
            "phoneNumber": phone,
            "startTime": start,
            "endTime": end,
            "date": date
        })
    })
        .then(response => response.text())
        .then(data => callback(data))
}