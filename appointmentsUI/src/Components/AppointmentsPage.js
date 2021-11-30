import React from 'react'
import { Component } from 'react'
import Button from './Button'
import { getAPI, importAPI, deleteAPI, updateAPI, addAPI } from '../API'
import AppointmentsList from './AppointmentsList'

class AppointmentsPage extends Component {

    state = {
        name: '',
        appointments: []
    }
    doGet = () => { getAPI(this.state.name, this.populateList) }
    doImport = () => { importAPI(this.imported) }
    doDelete = (id) => { deleteAPI(id, this.deleted) }
    doUpdate = (id, name, phone, email, start, end, date) => {updateAPI(id, name, phone, email, start, end, date, this.updated)}
    doAdd = (name, phone, email, start, end, date) => {addAPI(name, phone, email, start, end, date, this.updated)}

    // Callbacks
    populateList = (data) => {
        this.setState({
            appointments: data
        })}
    imported = (data) => {
        alert(data +' appointments to the backend.')
    }
    deleted = (data) => {
        alert(data ? 'Succesfully deleted the appointment ':'Failed to delete the specified appointment.')
    }
    updated = (data) => {
        alert(data)
    }
    added = (data) => {
        alert(data)
    }
    // End of callbacks
    render(){
        return(
            <div className='appointmentsPage'>
                <input onChange={(e) => this.setState({name : e.target.value})} placeholder='name'></input>
                <Button value='Get' onClick={this.doGet}></Button>
                <Button value='Import' onClick={this.doImport}></Button>
                <AppointmentsList
                    delete={this.doDelete}
                    update={this.doUpdate}
                    add={this.doAdd}
                    appointments={this.state.appointments}>
                </AppointmentsList>
            </div>
        )
    }
}
export default AppointmentsPage