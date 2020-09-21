import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { Alert, Button, Col, Container, Form, FormGroup, Input, Label, Row } from 'reactstrap';
import { ApplicationState } from '../store';
import * as CounterStore from '../store/Counter';

const Login = (props: RouteComponentProps<{}> ) => {
    const [visible, setVisible] = React.useState(true);
    const onDismiss = () => setVisible(false);
    return (
        <React.Fragment>
            <Container>
                <h1>登录</h1>
                <Alert color="danger" isOpen={visible} toggle={onDismiss}>
                    <h4 className="alert-heading">欢迎来到三次元废物逃避现实社区</h4>
                    <p>本社区需邀请进入</p>
                    <p>(懒)有空再改用户名密码注册</p>
                </Alert>
                <Row>
                    <Col xs = "6">
                        <Form width="500px">
                            <FormGroup>
                                <Label for="nickname">昵称</Label>
                                <Input type="text" name="nickname" id="nickname" placeholder="输入在社区中显式的名称" />
                            </FormGroup>
                            <FormGroup>
                                <Label for="invite-secret">邀请码</Label>
                                <Input type="text" name="secret" id="invite-secret" placeholder="邀请码" />
                            </FormGroup>
                        </Form>
                        <Button>进入</Button>
                    </Col>
                </Row>
            </Container>
        </React.Fragment>
    );
}

export default connect(
    (state: ApplicationState) => state.counter,
    CounterStore.actionCreators
)(Login);
