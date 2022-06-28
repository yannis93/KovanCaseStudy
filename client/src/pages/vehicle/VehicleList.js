import React,{ useState, useEffect, useRef } from 'react';
import { useNavigate } from "react-router-dom";
import {
  FormGroup,
  Label,
  Input,
  Button,
  Row,
  Col,
  Table,
  Modal,
  ModalHeader,
  ModalBody,
  ModalFooter, 
  ListGroup, 
  ListGroupItem
} from 'reactstrap';
import './VehicleList.css';
import {
    gql
  } from "@apollo/client";
import client from '../../core/client';
import Pagination from 'rc-pagination';
import 'rc-pagination/assets/index.css';
import Countdown from 'react-countdown';

  const renderer = ({ seconds }) => (
    <span>
      {seconds}
    </span>
  );

  export default function VehicleList () {
    const [vehicleType, setVehicleType] = useState("");
    const [bikeId, setBikeId] = useState("");
    const [page, setPageId] = useState(1);
    const [data, setData] = useState(null);
    const [isOpen, setIsOpen] = useState(false);
    const [totalValueBookingListedItems, setTotalValueBookingListedItems] = useState(0);
    const [selectedBike, setSelectedBike] = useState({});
    const [totalCount, setTotalCount] = useState(0);
    const [ttl, setTtl] = useState(0);
    const [isLoading, setIsLoading] = useState(false);
    const countDownRef = useRef(null);
    const navigate = useNavigate();

    useEffect(() => {
        GetVehicle(page, vehicleType, bikeId);
    },[]);

    useEffect(() => {
        GetVehicle(page, vehicleType, bikeId);
    }, [vehicleType, page]);
    useEffect(() => {
        if(isLoading){
            countDownRef.current.pause();
        }else{
            countDownRef.current.start();
        }        
    }, [isLoading]);

    function GetVehicle(page, vehicleType, bikeId) {
        setIsLoading(true);

        client
            .query({
                query: gql`
                {
                    vehicle(page:"${page}",vehicleType:"${vehicleType}") {
                        lastUpdated
                        ttl
                        data {
                        bikes{
                            bikeId,
                            lat,
                            lon,
                            isReserved,
                            isDisabled,
                            vehicleType,
                            totalBookings,
                            android,
                            ios
                        }
                        }
                        totalCount
                        nextPage
                    }
                    }
                `
            })
            .then((result) => {
                let totalBookingsValue = result.data.vehicle.data.bikes.reduce((s, f)=> {
                    return s + f.totalBookings
                }, 0)
                setData(result.data.vehicle);
                setTotalValueBookingListedItems(totalBookingsValue);
                setTotalCount(result.data.vehicle.totalCount);
                setData(result.data.vehicle);
                setIsLoading(false);
                setTtl(result.data.vehicle.ttl);
                countDownRef.current.start();
            }).catch((error)=>{
                console.log(error);
                localStorage.removeItem("token");
                navigate('/login');
            });
    }
    return (
        <Row>
        <Col xs={3}>
                <FormGroup>
                    <Label for="search">
                    Search By Bike Id
                    </Label>
                    <Input
                    id="search"
                    name="bikeId"
                    placeholder="search by bike id"
                    type="text"
                    />
                </FormGroup>
            </Col>
            <Col xs={3}>
                <FormGroup>
                    <Label for="vehicleType">
                    Filter by Vehicle Type
                    </Label>
                    <Input
                        id="vehicleType"
                        name="select"
                        type="select"
                        onChange={(event)=>{
                            let selectedTypeId = event.target.value;
                            let selectedTextValue= "";
                            
                            if(selectedTypeId == 1){
                                selectedTextValue = "scooter"
                            } else if(selectedTypeId == 2){
                                selectedTextValue = "bike"
                            }

                            setVehicleType( selectedTextValue);
                        }}>
                        <option value={0}>
                            All
                        </option>
                        <option value={1}>
                            scooter
                        </option>
                        <option value={2}>
                            bike
                        </option>
                    </Input>
                </FormGroup>
            </Col>
            <Col xs={6} className='float-end'>
                <Label className='d-block'>Will refresh in : {
                    <Countdown 
                        ref={countDownRef}
                        onComplete={()=>{
                            GetVehicle(page, vehicleType, bikeId);
                        }} 
                         
                        renderer={renderer} 
                        date={Date.now() + ttl * 1000} />} seconds</Label>
                    <Label className='d-block'>Total booking of listed Bikes: {totalValueBookingListedItems}</Label>
            </Col>
            <Col xs={12}>
                { isLoading ? "Loading..." : 
                    <Table hover>
                        <thead>
                            <tr>
                            <th>
                                Bike Id
                            </th>
                            <th>
                                Vehicle Type
                            </th>
                            <th>
                            </th>
                            </tr>
                        </thead>
                        { data != null ?  <tbody>
                            {data != null ? data.data.bikes.map((bike,index)=>{
                                return bike ? <tr key={index}>
                                <td>
                                    {bike.bikeId}
                                </td>
                                <td>
                                    {bike.vehicleType}
                                </td>
                                <td>
                                    <Button
                                        color="danger"
                                        onClick={() => {
                                            setIsOpen(true);
                                            setSelectedBike(bike);
                                        }}
                                    >
                                        Details
                                    </Button>
                                </td>
                                </tr>:""
                            }): ""}
                        </tbody> : ""}
                    </Table>
                }
                
                <Modal
                isOpen={isOpen}
                toggle={()=>setIsOpen(!isOpen)}>
                    <ModalHeader toggle={() => setIsOpen(false)}>
                        Vehicle Details
                    </ModalHeader>
                    <ModalBody>
                        <ListGroup>
                            <ListGroupItem><b>Bike Id</b>: {selectedBike.bikeId}</ListGroupItem>
                            <ListGroupItem><b>lat</b>: {selectedBike.lat}</ListGroupItem>
                            <ListGroupItem><b>lon</b>: {selectedBike.lon}</ListGroupItem>
                            <ListGroupItem><b>Reserved</b>: {selectedBike.isReserved ? "Yes":"No"}</ListGroupItem>
                            <ListGroupItem><b>Disabled</b>: {selectedBike.isDisabled ? "Yes":"No"}</ListGroupItem>
                            <ListGroupItem><b>Vehicle Type</b>: {selectedBike.vehicleType}</ListGroupItem>
                            <ListGroupItem><b>Total Booking</b>: {selectedBike.totalBooking}</ListGroupItem>
                            <ListGroupItem><b>Android</b>: <span>{selectedBike.android}</span></ListGroupItem>
                            <ListGroupItem><b>IOS</b>: <span>{selectedBike.ios}</span></ListGroupItem>
                        </ListGroup>
                    </ModalBody>
                    <ModalFooter>
                        <Button onClick={() => setIsOpen(false)}>
                            Close
                        </Button>
                    </ModalFooter>
                </Modal>
            </Col>
            <Col xs={12}>
                <Pagination simple current={page} total={totalCount} pageSize={10} onChange={(event) => {
                        setPageId(event)}}
                />
            </Col>
        </Row>
    );
}
