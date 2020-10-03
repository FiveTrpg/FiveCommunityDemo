import * as React from "react";
import { Col, Container, Row } from "reactstrap";

class Chat extends React.Component {
  render() {
    return (
      <Container>
        <Row>
          <Col>
            <Container>
              <Row>
                <h3>大厅</h3>
              </Row>
              <Row>
                <div contentEditable={true}>
                  阿团(uid #1) 2020-10-10<br />
                    奥里给！
                </div>
              </Row>
              <Row xs="3">
                <div contentEditable={true}>
                  请输入消息...
                </div>
              </Row>
            </Container>
          </Col>
          <Col xs="3">
            <Container>
              <Row>

              </Row>
            </Container>
          </Col>
        </Row>
      </Container>
    );
  }
}

export default Chat;
