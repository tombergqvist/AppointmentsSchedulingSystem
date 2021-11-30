import React from 'react'
import { Component } from 'react'
import Button from './Button'

class AppointmentsList extends Component {

    state = {
        appointments: [],
        toAdd: {}
    }

    componentDidMount() {
        this.setState({
            toAdd: {
                name: '',
                email: '',
                phoneNumber: '',
                startTime: '',
                endTime: '',
                date: ''
            }
        })
    }

    static getDerivedStateFromProps(props, state) {
        state.appointments = props.appointments
        return state
    }

    onChange(id, val, type) {
        let update = this.state.appointments
        let index = update.findIndex(obj => obj.id === id)
        switch (type) {
            case 'name':
                update[index].name = val
                break;
            case 'email':
                update[index].email = val
                break;
            case 'phoneNumber':
                update[index].phoneNumber = val
                break;
            case 'startTime':
                update[index].startTime = val
                break;
            case 'endTime':
                update[index].endTime = val
                break;
            case 'date':
                update[index].date = val
                break;
        }
        this.setState({ appointments: update })
    }
    addOnChange(val, type) {
        let add = this.state.toAdd
        switch (type) {
            case 'name':
                add.name = val
                break;
            case 'email':
                add.email = val
                break;
            case 'phoneNumber':
                add.phoneNumber = val
                break;
            case 'startTime':
                add.startTime = val
                break;
            case 'endTime':
                add.endTime = val
                break;
            case 'date':
                add.date = val
                break;
        }
        this.setState({ toAdd: add })
    }

    addInputs() {
        let t = this.state.toAdd
        let div = <div className='row'>
            <div className='col'>
                <Button value='Add' onClick={() =>
                    this.props.add(t.name, t.phoneNumber, t.email, t.startTime, t.endTime, t.date)}
                    key={'add'}>
                </Button>
            </div>
            <div className='col'>
                <input onChange={
                    (e) => this.addOnChange(e.target.value, 'name')}
                    placeholder='name'>
                </input>
            </div>
            <div className='col'>
                <input onChange={
                    (e) => this.addOnChange(e.target.value, 'phoneNumber')}
                    placeholder='phoneNumber'>
                </input>
            </div>
            <div className='col'>
                <input onChange={
                    (e) => this.addOnChange(e.target.value, 'email')}
                    placeholder='email'>
                </input>
            </div>
            <div className='col'>
                <input onChange={
                    (e) => this.addOnChange(e.target.value, 'startTime')}
                    placeholder='startTime'>
                </input>
            </div>
            <div className='col'>
                <input onChange={
                    (e) => this.addOnChange(e.target.value, 'endTime')}
                    placeholder='endTime'>
                </input>
            </div>
            <div className='col'>
                <input onChange={
                    (e) => this.addOnChange(e.target.value, 'date')}
                    placeholder='date'>
                </input>
            </div>
        </div>
        return div
    }

    render() {
        let apps = []
        for (let a of this.props.appointments) {

            let index = this.state.appointments.findIndex(obj => obj.id === a.id)
            let row = this.state.appointments[index]

            apps.push(<div className='row' >
                <div className='col'>
                    <Button onClick={() => this.props.delete(a.id)} value='Delete' key={'delete' + a.id}></Button>
                    <Button value='Update' onClick={() =>
                        this.props.update(a.id, row.name, row.phoneNumber, row.email, row.startTime, row.endTime, row.date)}
                        key={'update' + a.id}>
                    </Button>
                    {a.id}
                </div>
                <div className='col'>
                    <input onChange={
                        (e) => this.onChange(a.id, e.target.value, 'name')}
                        value={row.name}>
                    </input>
                </div>
                <div className='col'>
                    <input onChange={
                        (e) => this.onChange(a.id, e.target.value, 'phoneNumber')}
                        value={row.phoneNumber}>
                    </input></div>
                <div className='col'>
                    <input onChange={
                        (e) => this.onChange(a.id, e.target.value, 'email')}
                        value={row.email}>
                    </input></div>
                <div className='col'>
                    <input onChange={
                        (e) => this.onChange(a.id, e.target.value, 'startTime')}
                        value={row.startTime}>
                    </input></div>
                <div className='col'>
                    <input onChange={
                        (e) => this.onChange(a.id, e.target.value, 'endTime')}
                        value={row.endTime}>
                    </input></div>
                <div className='col'>
                    <input onChange={
                        (e) => this.onChange(a.id, e.target.value, 'date')}
                        value={row.date}>
                    </input></div>
            </div>)
        }
        let addInputs = this.addInputs()
        return (
            <div className='appointmentsList'>
                {addInputs}
                <div className='row'>
                    <div className='col'>id</div>
                    <div className='col'>name</div>
                    <div className='col'>phone</div>
                    <div className='col'>email</div>
                    <div className='col'>start</div>
                    <div className='col'>end</div>
                    <div className='col'>date</div>
                </div>
                {apps}
            </div>
        )
    }
}
export default AppointmentsList