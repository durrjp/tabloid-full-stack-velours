import React, { useState } from "react";
import {
  ListGroupItem,
  ListGroup,
  Modal,
  ModalHeader,
  ModalBody,
} from "reactstrap";
import "./UserProfile.css";
import { useHistory } from "react-router-dom";
import { EditUserType } from "./EditUserType";

export const DeactivatedUserProfile = ({ userProfile }) => {
  const [modal, setModal] = useState(false);
  const toggleModal = () => setModal(!modal);
  const history = useHistory();
  const handleClick = () => {
    history.push(`/userprofiles/${userProfile.id}`);
  };

    return (
      <>
    {(userProfile.IsActivated === 0) && (
      <>
      
      <ListGroupItem>
      <ListGroup horizontal className="userProfile">
        <div className="user--info">{userProfile.fullName}</div>
        <div className="user--info">{userProfile.displayName}</div>
        <div className="user--info">{userProfile.userType.name}</div>
        <ListGroup horizontal>
          <div className="icon--userProfile">
            <i
              onClick={handleClick}
              className="fa fa-info-circle"
              aria-hidden="true"
            ></i>
          </div>
          <div className="icon--userProfile">
            <i
              onClick={() => toggleModal()}
              className="fa fa-pencil-square-o"
              aria-hidden="true"
            ></i>
          </div>
        </ListGroup>
      </ListGroup>
    </ListGroupItem>

    <Modal
      isOpen={modal}
      modalTransition={{ timeout: 700 }}
      backdropTransition={{ timeout: 1300 }}
      toggle={toggleModal}
      contentClassName="custom-modal-style-product"
    >
      <ModalHeader toggle={toggleModal}>Edit User Type</ModalHeader>
      <ModalBody>
        <EditUserType userProfile={userProfile} toggle={toggleModal} />
      </ModalBody>
    </Modal>
    </>
    )

    }

      </>
    );
  
};
